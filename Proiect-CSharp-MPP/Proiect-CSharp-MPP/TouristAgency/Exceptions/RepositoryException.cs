using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_CSharp_MPP.TouristAgency.Exceptions
{
    public class RepositoryException : ApplicationException
    {
        public RepositoryException(string message) : base(message) { }
    }
}
