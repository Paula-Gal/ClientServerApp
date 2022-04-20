using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_CSharp_MPP.TouristAgency.Domain
{
    public class Flight : Entity<int>
    {
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Airport { get; set; }
        public int NumberOfAvailablePlaces { get; set; }

        public Flight(string destination, DateTime departureDate, string airport, int numberOfAvailablePlaces)
        {
            Destination = destination;
            DepartureDate = departureDate;
            Airport = airport;
            NumberOfAvailablePlaces = numberOfAvailablePlaces;
        }

        public override string ToString()
        {
            return "Flight{ " + "Destination: " + Destination + "DepartureDate: " + DepartureDate + "Airport: " + Airport + "Seats: " + NumberOfAvailablePlaces + " }";
        }
    }
}
