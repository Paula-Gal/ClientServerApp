using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Repository;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using Proiect_CSharp_MPP.TouristAgency.Validators;

namespace Proiect_CSharp_MPP.TouristAgency.Service
{
    public class Service
    {
        private ICustomerRepository customerRepo;
        private IEmployeeRepository employeeRepo;
        private IFlightRepository flightRepo;
        private ITicketRepository ticketRepo;
        private TicketValidator ticketValidator;
        private CustomerValidator customerValidator;

        public Service(ICustomerRepository customerRepo, IEmployeeRepository employeeRepo, IFlightRepository flightRepo, ITicketRepository ticketRepo, TicketValidator ticketValidator, CustomerValidator customerValidator)
        {
            this.customerRepo = customerRepo;
            this.employeeRepo = employeeRepo;
            this.flightRepo = flightRepo;
            this.ticketRepo = ticketRepo;
            this.ticketValidator = ticketValidator;
            this.customerValidator = customerValidator;
        }

        public Employee Login(String username, String password)
        {
            Employee employee = employeeRepo.FindByUsername(username);
            if(employee == null)
            {
                throw new ServiceException("Non-existent username!\n");
            }
            if(!employee.Password.Equals(password))
            {
                throw new ServiceException("Wrong password!\n");
            }
            return employee;
        }

        public void purchaseTicket(string customerName, string customerCnp, string customerAddress, int flightId, List<string> tourists, int seats)
        {
            Flight flight = flightRepo.FindOne(flightId);
            if(flight == null)
            {
                throw new ServiceException("Non-existent flight!\n");
            }
            if(flight.NumberOfAvailablePlaces < seats)
            {
                throw new ServiceException("There are not so many seats available!\n");
            }
            Customer customer = customerRepo.FindByCnp(customerCnp);
            if(customer == null)
            {
                Customer customerToAdd = new Customer(customerName, customerCnp, customerAddress);
                customerValidator.Validate(customerToAdd);
                customerRepo.Add(customerToAdd);
            }
            Customer customerFound = customerRepo.FindByCnp(customerCnp);
            if(customerFound == null)
            {
                throw new ServiceException("Non-existent customer!\n");
            }
            Ticket ticket = new Ticket(customerFound, tourists, seats, flight);
            ticketValidator.Validate(ticket);
            ticketRepo.Add(ticket);
            int newNumberOfSeats = flight.NumberOfAvailablePlaces - seats;
            Flight updatedFlight = new Flight(flight.Destination, flight.DepartureDate, flight.Airport, newNumberOfSeats);
            flightRepo.Update(updatedFlight, flightId);
        }

        public List<Flight> FilterByDestinationAndDepartureDate(string destination, DateTime departureDate)
        {
            return flightRepo.FindByDestinationAndDepartureDate(destination, departureDate);
        }

        public List<Flight> GetAllFlights()
        {
            return flightRepo.FindAll().ToList();
        }

    }
}
