using Model.Domain;
using Services;
using System;
using System.Collections.Generic;


namespace Client
{
    public class EmployeePageController : IObserver
    {
        public event EventHandler<EmployeeEventArgs> updateEvent;
        private readonly IServices server;
        public EmployeePageController(IServices server)
        {
            this.server = server;
            Console.WriteLine("Hello");
        }

        public List<Flight> GetAllFlights()
        {
            return server.GetAllFlights();
        }

        public List<Flight> FilterByDestinationAndDepartureDate(string destination, DateTime departureDate)
        {
            return server.FilterByDestinationAndDepartureDate(destination, departureDate);
        }

        public IServices GetService()
        {
            return server;
        }

        protected virtual void OnEmployeeEvent(EmployeeEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Method updateEvent called ...");
        }

        public void ticketPurchased(Ticket ticket)
        {
            Console.WriteLine("Ticket buyed!");
            EmployeeEventArgs e = new EmployeeEventArgs(EmployeeEvent.TicketPurchased, ticket);
            OnEmployeeEvent(e);
        }
    }
}
