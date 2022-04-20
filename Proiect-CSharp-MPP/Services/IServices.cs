using Model.Domain;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IServices
    {
        Employee Login(String username, String password, IObserver client);
        void Logout(Employee employee);
        
        void purchaseTicket(string customerName, string customerCnp, string customerAddress, Flight flight, List<string> tourists, int seats);
        List<Flight> FilterByDestinationAndDepartureDate(string destination, DateTime departureDate);
        List<Flight> GetAllFlights();
        Flight getFlightByID(int flight);
    }
}
