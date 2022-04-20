using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    [Serializable]
    public class GetAllFlightsResponse : Response
    {
        List<Flight> allFlights;
        public GetAllFlightsResponse(List<Flight> allFlights)
        {
            this.allFlights = allFlights;
        }

        public virtual List<Flight> AllFlights
        {
            get { return allFlights; }
        }
    }
}
