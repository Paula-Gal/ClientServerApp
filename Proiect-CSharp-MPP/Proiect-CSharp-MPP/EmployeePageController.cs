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
    public class EmployeePageController
    {
        private readonly Service service;
        public EmployeePageController(Service service)
        {
            this.service = service;
        }

        public List<Flight> GetAllFlights()
        {
            return service.GetAllFlights();
        }

        public List<Flight> FilterByDestinationAndDepartureDate(string destination, DateTime departureDate)
        {
            return service.FilterByDestinationAndDepartureDate(destination, departureDate);
        }

        public Service GetService()
        {
            return service;
        }

    }
}
