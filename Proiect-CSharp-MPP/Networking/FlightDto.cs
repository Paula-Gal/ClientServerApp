using System;

namespace Networking
{
    [Serializable]
    public class FlightDto
    {
        string destination;
        DateTime departureDate;

        public FlightDto(string destination, DateTime departureDate)
        {
            this.destination = destination;
            this.departureDate = departureDate;
        }

        public string Destination
        {
            get { return destination; }
        }

        public DateTime DepartureDate
        {
            get { return departureDate; }
        }
    }
}
