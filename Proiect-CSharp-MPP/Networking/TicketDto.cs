using System;
using System.Collections.Generic;
using Model.Domain;

namespace Networking
{
    [Serializable]
    public class TicketDto
    {
        private string customerName;
        private string customerCnp;
        private string customerAddress;
        private Flight flightId;
        private List<string> tourists;
        private int seats;

        public TicketDto(string customerName, string customerCnp, string customerAddress, Flight flightId, List<string> tourists, int seats)
        {
            this.customerName = customerName;
            this.customerCnp = customerCnp;
            this.customerAddress = customerAddress;
            this.flightId = flightId;
            this.tourists = tourists;
            this.seats = seats;
        }

        public string CustomerName
        {
            get { return customerName; }
        }

        public string CustomerCnp
        {
            get { return customerCnp; }
        }

        public string CustomerAddress
        {
            get { return customerAddress; }
        }

        public Flight FlightId
        {
            get { return flightId; }
        }

        public List<string> Tourists
        {
            get { return tourists; }
        }

        public int Seats
        {
            get { return seats; }
        }
    }
}
