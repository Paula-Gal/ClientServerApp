using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Service;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Proiect_CSharp_MPP
{
    public class PurchaseTicketPageController
    {
        private readonly Service service;
        public PurchaseTicketPageController(Service service)
        {
            this.service = service;
        }

        public void purchaseTicket(string customerName, string customerCnp, string customerAddress, int flightId, List<string> tourists, int seats)
        {
            service.purchaseTicket(customerName, customerCnp, customerAddress, flightId, tourists, seats);
        }

    }
}
