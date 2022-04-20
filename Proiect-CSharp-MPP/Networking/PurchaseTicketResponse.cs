using System;
using Model.Domain;

namespace Networking
{
    [Serializable]
    public class PurchaseTicketResponse : UpdateResponse
    {
        private TicketDto ticketDto;
        
        public PurchaseTicketResponse(TicketDto ticketDto)
        {
            this.ticketDto = ticketDto;
        }

        public virtual TicketDto Ticket
        {
            get
            {
                return ticketDto;
            }
        }
    }
}
