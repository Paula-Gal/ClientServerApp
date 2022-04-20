using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_CSharp_MPP.TouristAgency.Exceptions
{
    public class ServiceException : ApplicationException
    {
        public ServiceException(string message) : base(message) { }
    }
}
