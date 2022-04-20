﻿using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IFlightRepository : ICRUDRepository<int, Flight>
    {
        List<Flight> FindByDestinationAndDepartureDate(string destionation, DateTime departureDate);
    }
}
