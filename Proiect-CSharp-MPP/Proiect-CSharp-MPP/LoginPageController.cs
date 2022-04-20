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
    public class LoginPageController
    {
        private readonly Service service;
        public LoginPageController(Service service)
        {
            this.service = service;
        }

        public Employee Login(string username, string password)
        {
            return service.Login(username, password);
        }

        public Service GetService()
        {
            return service;
        }

    }
}
