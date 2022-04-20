using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain;

namespace Services
{
    public interface IObserver
    {
        void ticketPurchased(Ticket ticket);
    }
}
