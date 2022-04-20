using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    [Serializable]
    public class SearchFlightsResponse : Response
    {
        List<Flight> flights;
        public SearchFlightsResponse(List<Flight> flights)
        {
            this.flights = flights;
        }

        public virtual List<Flight> Flights
        {
            get { return flights; }
        }
    }
}
