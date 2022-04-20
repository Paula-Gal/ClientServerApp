using System;

namespace Networking
{
    [Serializable]
    public class SearchFlightsRequest : Request
    {
        private FlightDto flightDto;

        public SearchFlightsRequest(FlightDto flightDto)
        {
            this.flightDto = flightDto;
        }

        public virtual FlightDto Flight
        {
            get { return flightDto; }
        }
    }
}
