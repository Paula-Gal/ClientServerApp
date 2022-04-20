using System;

namespace Networking
{
    [Serializable]
    public class PurchaseTicketRequest : Request
    {
        private TicketDto ticketDto;

        public PurchaseTicketRequest(TicketDto ticketDto)
        {
            this.ticketDto = ticketDto;
        }

        public virtual TicketDto Ticket
        {
            get { return ticketDto; }
        }
    }
}
