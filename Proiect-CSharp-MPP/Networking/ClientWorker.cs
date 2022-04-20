using Model.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Networking
{
    public class ClientWorker : IObserver
    {
        private IServices server;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        
        public ClientWorker(IServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

		public virtual void Run()
		{
			while (connected)
			{
				try
				{
					object request = formatter.Deserialize(stream);
					object response = HandleRequest((Request)request);
					if (response != null)
					{
						SendResponse((Response)response);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.StackTrace);
				}

				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error " + ex);
			}
		}

		private void SendResponse(Response response)
		{
			Console.WriteLine("Sending Response " + response);
			formatter.Serialize(stream, response);
			stream.Flush();
		}

		public virtual void ticketPurchased(Ticket ticket)
		{
			TicketDto ticketDto = new TicketDto(ticket.Customer.Name, ticket.Customer.CNP, ticket.Customer.Address,
				ticket.Flight, ticket.Tourists, ticket.NumberOfPlaces);
			Console.WriteLine("Current ticket: "+ticketDto);
            try
			{
				SendResponse(new PurchaseTicketResponse(ticketDto));
			}
			catch(Exception ex)
			{
				throw new ServerException("Sending error " + ex);
			}
        }

		private Response HandleRequest(Request request)
		{
			Response response = null;
			if(request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest loginRequest = (LoginRequest)request;
				EmployeeDto employeeDto = loginRequest.Employee;
				try
				{
					Employee employee = null;
					lock(server)
					{
						employee = server.Login(employeeDto.Username, employeeDto.Password, this);
					}
					return new LoginResponse(employee);
				}
				catch(ServiceException ex)
				{
					connected = false;
					return new ErrorResponse(ex.Message);
				}
			}
			if(request is LogoutRequest)
			{
				Console.WriteLine("Logout request ...");
				LogoutRequest logoutRequest = (LogoutRequest)request;
				Employee employee = logoutRequest.Employee;
				try
				{
					lock(server)
					{
						server.Logout(employee);
					}
				}
				catch(ServiceException ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}
			if(request is PurchaseTicketRequest)
			{
				Console.WriteLine("Purchase Ticket Request ...");
				PurchaseTicketRequest purchaseTicketRequest = (PurchaseTicketRequest)request;
				TicketDto ticketDto = purchaseTicketRequest.Ticket;
				try
				{
					lock(server)
					{
						server.purchaseTicket(ticketDto.CustomerName, ticketDto.CustomerCnp, ticketDto.CustomerAddress, ticketDto.FlightId, ticketDto.Tourists, ticketDto.Seats);
					}

					return new OkResponse();
				}
				catch(ServiceException ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}
			if(request is GetAllFlightsRequest)
			{
				Console.WriteLine("Get All Flights Request ...");
				GetAllFlightsRequest getAllFlightsRequest = (GetAllFlightsRequest)request;
				try
				{
					List<Flight> allFlights;
					lock(server)
					{
						allFlights = server.GetAllFlights();
					}
					return new GetAllFlightsResponse(allFlights);
				}
				catch(ServiceException ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}
			if(request is SearchFlightsRequest)
			{
				Console.WriteLine("Search Flights Request ...");
				SearchFlightsRequest searchFlightsRequest = (SearchFlightsRequest)request;
				FlightDto flightDto = searchFlightsRequest.Flight;
				try
				{
					List<Flight> flights;
					lock (server)
					{
						flights = server.FilterByDestinationAndDepartureDate(flightDto.Destination, flightDto.DepartureDate);
					}
					return new SearchFlightsResponse(flights);
				}
				catch (ServiceException ex)
				{
					return new ErrorResponse(ex.Message);
				}
			}

			// if (request is GetFlightByID)
			// {
			// 	Console.WriteLine("Get Flights by ID Request ...");
			// 	GetFlightByID req = (GetFlightByID)request;
			// 	int flight = (int)req.fl;
			// 	Flight flightO;
			// 	try
			// 	{
			// 		lock (server)
			// 		{
			// 			flightO = server.getFlightByID(flight);
			// 		}
			//
			// 		return new GetFlightByIDResponse(flightO);
			// 	}
			// 	catch (ServiceException ex)
			// 	{
			// 		return new ErrorResponse(ex.Message);
			// 	}
			// }
			return response;
		}

	}
}
