using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain;

namespace Client
{
    public class PurchaseTicketPageController
    {
        private readonly IServices server;
        public PurchaseTicketPageController(IServices server)
        {
            this.server = server;
        }

        public void purchaseTicket(string customerName, string customerCnp, string customerAddress, Flight flight, List<string> tourists,  int seats)
        {
            server.purchaseTicket(customerName, customerCnp, customerAddress, flight, tourists, seats);
        }

    }
}
