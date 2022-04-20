using System;
using Model.Domain;

namespace Networking
{
    [Serializable]
    public class GetFlightByIDResponse : Response
    {
       Flight flight;
        public GetFlightByIDResponse(Flight flight)
        {
            this.flight = flight;
        }

        public virtual Flight Flight
        {
            get { return flight; }
        }
    }
}
