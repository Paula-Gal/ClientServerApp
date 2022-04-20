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
    public class ServerProxy : IServices
    {
        private string host;
        private int port;
        private IObserver client;
        private NetworkStream stream;
        private IFormatter formatter;
        private TcpClient connection;
        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        public ServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }

        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                // TcpClient tcpClient = new TcpClient ();
                // tcpClient.Connect(host,port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                StartReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void StartReader()
        {
            Thread tw = new Thread(Run);
            tw.Start();
        }

        public virtual void Run()
        {
            while(!finished)
            {
                try
                {
                    Response response = (Response) formatter.Deserialize(stream);
                    Console.WriteLine("Response received " + response);
                    if(response is UpdateResponse)
                    {
                        Console.WriteLine("handle update enter - proxy");
                        HandleUpdate((UpdateResponse)response);
                    }
                    else
                    {
                        lock(responses)
                        {
                            responses.Enqueue((Response)response);
                        }
                        _waitHandle.Set();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Reading error " + ex);
                }
            }
        }

        private void SendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch(Exception ex)
            {
                throw new ServerException("Error sending object " + ex);
            }
        }

        private Response ReadResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock(responses)
                {
                    response = responses.Dequeue();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return response;
        }

        private void CloseConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                connection.Close();
                _waitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void HandleUpdate(UpdateResponse updateResponse)
        {
            if (updateResponse is PurchaseTicketResponse)
            {
                Console.WriteLine("Take the response - proxy");
                PurchaseTicketResponse resp = (PurchaseTicketResponse) updateResponse;
                TicketDto ticketDto = (TicketDto) resp.Ticket;
                Customer customer = new Customer(resp.Ticket.CustomerName, resp.Ticket.CustomerCnp,
                    resp.Ticket.CustomerAddress);
                // Flight flight = new Flight("Olanda",DateTime.Now , "Hendri", 12);
                Ticket ticket = new Ticket(customer, ticketDto.Tourists, ticketDto.Seats,  ticketDto.FlightId);
                try
                {
                    Console.WriteLine("Ticket purchased - proxy");
                    client.ticketPurchased(ticket);
                }
                catch(ServiceException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        public virtual Employee Login(string username, string password, IObserver client)
        {
            initializeConnection();
            EmployeeDto employeeDto = new EmployeeDto(username, password);
            SendRequest(new LoginRequest(employeeDto));
            Response response = ReadResponse();
            if(response is LoginResponse)
            {
                this.client = client;
            }
            if(response is ErrorResponse)
            {
                ErrorResponse error = (ErrorResponse)response;
                CloseConnection();
                throw new ServerException(error.Message);
            }
            LoginResponse loginResponse = (LoginResponse)response;
            return loginResponse.Employee;
        }

        public virtual void Logout(Employee employee)
        {
            SendRequest(new LogoutRequest(employee));
            Response response = ReadResponse();
            CloseConnection();
            if(response is ErrorResponse)
            {
                ErrorResponse error = (ErrorResponse)response;
                throw new ServerException(error.Message);
            }
        }

        public virtual List<Flight> FilterByDestinationAndDepartureDate(string destination, DateTime departureDate)
        {
            FlightDto flightDto = new FlightDto(destination, departureDate);
            SendRequest(new SearchFlightsRequest(flightDto));
            Response response = ReadResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse error = (ErrorResponse)response;
                throw new ServerException(error.Message);
            }
            SearchFlightsResponse searchFlightsResponse = (SearchFlightsResponse)response;
            return searchFlightsResponse.Flights;
        }

        public virtual List<Flight> GetAllFlights()
        {
            SendRequest(new GetAllFlightsRequest());
            Response response = ReadResponse();
            if(response is ErrorResponse)
            {
                ErrorResponse error = (ErrorResponse)response;
                throw new ServerException(error.Message);
            }
            GetAllFlightsResponse getAllFlightsResponse = (GetAllFlightsResponse)response;
            return getAllFlightsResponse.AllFlights;
        }

        public Flight getFlightByID(int flight)
        {
           SendRequest(new GetFlightByID(flight));
           Response response = ReadResponse();
           if (response is ErrorResponse)
           {
               ErrorResponse error = (ErrorResponse)response;
               throw new ServerException(error.Message);
           }

           GetFlightByIDResponse getFlightByIdResponse = (GetFlightByIDResponse) response;
           return getFlightByIdResponse.Flight;
        }

        public virtual void purchaseTicket(string customerName, string customerCnp, string customerAddress, Flight flight, List<string> tourists, int seats)
        {
            TicketDto ticketDto = new TicketDto(customerName, customerCnp, customerAddress, flight,tourists, seats);
            SendRequest(new PurchaseTicketRequest(ticketDto));
            Console.WriteLine("A");
            Response response = ReadResponse();
            Console.WriteLine("B");
            if(response is ErrorResponse)
            {
                ErrorResponse error = (ErrorResponse)response;
                throw new ServiceException(error.Message);
            }
            
        }
    }
}
