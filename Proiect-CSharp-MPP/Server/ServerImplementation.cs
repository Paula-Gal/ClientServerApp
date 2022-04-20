using Model.Domain;
using Model.Validators;
using Persistence;
using Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class ServerImplementation: IServices
    {
        private ICustomerRepository customerRepo;
        private IEmployeeRepository employeeRepo;
        private IFlightRepository flightRepo;
        private ITicketRepository ticketRepo;
        private TicketValidator ticketValidator;
        private CustomerValidator customerValidator;
        private IDictionary<int, IObserver> loggedEmployees;

        public ServerImplementation(ICustomerRepository customerRepo, IEmployeeRepository employeeRepo, IFlightRepository flightRepo, ITicketRepository ticketRepo, TicketValidator ticketValidator, CustomerValidator customerValidator)
        {
            this.customerRepo = customerRepo;
            this.employeeRepo = employeeRepo;
            this.flightRepo = flightRepo;
            this.ticketRepo = ticketRepo;
            this.ticketValidator = ticketValidator;
            this.customerValidator = customerValidator;
            this.loggedEmployees = new ConcurrentDictionary<int, IObserver>();
        }

        public Employee Login(String username, String password, IObserver client)
        {
            Employee employee = employeeRepo.FindByUsername(username);
            if (employee == null)
            {
                throw new ServiceException("Non-existent username!\n");
            }
            if (!employee.Password.Equals(password))
            {
                throw new ServiceException("Wrong password!\n");
            }
            if(loggedEmployees.ContainsKey(employee.ID))
            {
                throw new ServiceException("You're already logged in!\n");
            }
            loggedEmployees.Add(employee.ID, client);
            return employee;
        }

        public void Logout(Employee employee)
        {
            if(!loggedEmployees.ContainsKey(employee.ID))
            {
                throw new ServiceException("User not logged in!\n");
            }
            loggedEmployees.Remove(employee.ID);
        }

        private void notifyEmployees(Ticket ticket)
        {
            Console.WriteLine("notify employees function");
            foreach(KeyValuePair<int, IObserver> loggedEmployee in loggedEmployees)
            {
                IObserver client = loggedEmployees[loggedEmployee.Key];
                Task.Run(() => client.ticketPurchased(ticket));
            }
        }

        public void purchaseTicket(string customerName, string customerCnp, string customerAddress, Flight flightId, List<string> tourists,  int seats)
        {
            // Flight flight = flightRepo.FindOne(flightId.ID);
            // if (flight == null)
            // {
            //     throw new ServiceException("Non-existent flight!\n");
            // }
            // if (flight.NumberOfAvailablePlaces < seats)
            // {
            //     throw new ServiceException("There are not so many seats available!\n");
            // }
            // Customer customer = customerRepo.FindByCnp(customerCnp);
            // if (customer == null)
            // {
            //     Customer customerToAdd = new Customer(customerName, customerCnp, customerAddress);
            //     customerValidator.Validate(customerToAdd);
            //     customerRepo.Add(customerToAdd);
            // }
            // Customer customerFound = customerRepo.FindByCnp(customerCnp);
            // if (customerFound == null)
            // {
            //     throw new ServiceException("Non-existent customer!\n");
            // }
            Console.WriteLine("purchase ticket - server");
            Customer customer = new Customer(customerName, customerCnp, customerAddress);
            Ticket ticket = new Ticket(customer, tourists, seats, flightId);
            ticketValidator.Validate(ticket);
            ticketRepo.Add(ticket);
            int newNumberOfSeats = flightId.NumberOfAvailablePlaces - seats;
            Flight updatedFlight = new Flight(flightId.Destination, flightId.DepartureDate, flightId.Airport, newNumberOfSeats);
            flightRepo.Update(updatedFlight, flightId.ID);
            notifyEmployees(ticket);
        }

        public List<Flight> FilterByDestinationAndDepartureDate(string destination, DateTime departureDate)
        {
            return flightRepo.FindByDestinationAndDepartureDate(destination, departureDate);
        }

        public List<Flight> GetAllFlights()
        {
            return flightRepo.FindAll().ToList();
        }

        public Flight getFlightByID(int flight)
        {
            return flightRepo.FindOne(flight);
        }
    }
}