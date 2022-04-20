using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Serializable]
    public class Ticket : Entity<int>
    {
        public Customer Customer { set; get; }
        public List<string> Tourists { get; set; }
        public int NumberOfPlaces { set; get; }
        public Flight Flight { set; get; }
        public Ticket(Customer customer, List<string> tourists, int numberOfPlaces, Flight flight)
        {
            Customer = customer;
            Tourists = tourists;
            NumberOfPlaces = numberOfPlaces;
            Flight = flight;
        }

        public override string ToString()
        {
            return "Ticket{ " + "Customer: " + Customer + "Tourists: " + Tourists + "Seats: " + NumberOfPlaces + "Flight: " + Flight + " }";
        }
    }
}
