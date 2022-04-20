using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{   
    [Serializable]
    public class Employee : Entity<int>
    {
        public string Username
        {
            set; get;
        }
        public string Password
        {
            set; get;
        }
        public Employee() { }

        public Employee(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return "Employee{ Username: " + Username + "Password: " + Password + " }";
        }
    }
}
