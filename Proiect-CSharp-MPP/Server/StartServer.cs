using Model.Validators;
using Persistence;
using Services;
using System;
using System.Collections.Generic;
using Model.Domain;
using Networking;

namespace Server
{
    class StartServer
    {
        static void Main(string[] args)
        {
            ICustomerRepository customerRepo = new CustomerDBRepository();
            IFlightRepository flightRepo = new FlightDBRepository();
            IEnumerable<Flight> fl = flightRepo.FindAll();
            IEmployeeRepository employeeRepo = new EmployeeDBRepository();
            ITicketRepository ticketRepo = new TicketDBRepository();
            TicketValidator ticketValidator = new TicketValidator();
            CustomerValidator customerValidator = new CustomerValidator();
            IServices services = new ServerImplementation(customerRepo, employeeRepo, flightRepo, ticketRepo, ticketValidator, customerValidator);
            SerialServer server = new SerialServer("127.0.0.1", 55565, services);
            Console.WriteLine("Server started ..." + server);
           // Console.ReadLine();
            try
            {
                server.Start();
            }
            catch (ServerException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
