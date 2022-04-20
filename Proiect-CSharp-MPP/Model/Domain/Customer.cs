using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Serializable]
    public class Customer : Entity<int>
    {
        public string Name { get; set; }
        public string CNP { get; set; }
        public string Address { get; set; }

        public Customer(string name, string cnp, string address)
        {
            Name = name;
            CNP = cnp;
            Address = address;
        }

        public override string ToString()
        {
            return "Customer{ " + "Name: " + Name + "CNP: " + CNP + "Address: " + Address + " }";
        }
    }
}
