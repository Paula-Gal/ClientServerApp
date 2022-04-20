using Proiect_CSharp_MPP.TouristAgency.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Persistence
{

    class FlightDBRepository : IFlightRepository
    {
        private static readonly ILog log = LogManager.GetLogger("FlightDBRepository");
        public FlightDBRepository()
        {
            log.Info("Creating FlightDBRepository");
        }
        public Flight FindOne(int id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
            IDbConnection con = DBUtils.GetConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from flights where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataReader = comm.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        string destination = dataReader.GetString(1);
                        //long timeStampMilliSeconds = dataReader.GetInt64(2);
                        // DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        // DateTime departureDate = start.AddMilliseconds(timeStampMilliSeconds).ToLocalTime();
                        String depDate = dataReader.GetString(2);
                        DateTime dateTime = DateTime.Parse(depDate);
                        string airport = dataReader.GetString(3);
                        int seats = dataReader.GetInt32(4);
                        Flight flight = new Flight(destination, dateTime, airport, seats);
                        flight.ID = id;
                        log.InfoFormat("Exiting FindOne with value {0}", flight);
                        return flight;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public void Add(Flight flight)
        {
            log.InfoFormat("Entering Add with value {0}", flight);
            IDbConnection connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into flights(destination, departure, airport, seats) values(@destination, @departure, @airport, @seats)";

                var paramDestination = command.CreateParameter();
                paramDestination.ParameterName = "@destination";
                paramDestination.Value = flight.Destination;
                command.Parameters.Add(paramDestination);

                var paramDepartureDate = command.CreateParameter();
                paramDepartureDate.ParameterName = "@departure";
                paramDepartureDate.Value = flight.DepartureDate;
                command.Parameters.Add(paramDepartureDate);

                var paramAirport = command.CreateParameter();
                paramAirport.ParameterName = "@airport";
                paramAirport.Value = flight.Airport;
                command.Parameters.Add(paramAirport);

                var paramSeats = command.CreateParameter();
                paramSeats.ParameterName = "@seats";
                paramSeats.Value = flight.NumberOfAvailablePlaces;
                command.Parameters.Add(paramSeats);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Add - No flight added");
                    throw new RepositoryException("No flight added!");
                }
            }
            log.InfoFormat("Exiting Add - Flight added successfully");
        }

        public void Delete(Flight flight)
        {
            log.InfoFormat("Entering Delete with value {0}", flight);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from flights where id=@id";
                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = flight.ID;
                command.Parameters.Add(paramId);
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting add - No flight deleted");
                    throw new RepositoryException("No flight deleted!");
                }
            }
            log.InfoFormat("Exiting Delete - Flight deleted successfully");
        }

        public void Update(Flight flight, int id)
        {
            log.InfoFormat("Entering Update with values {0}, {1}", flight, id);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update flights set destination=@destination, airport=@airport, seats=@seats where id=@id";
                var paramDestination = command.CreateParameter();
                paramDestination.ParameterName = "@destination";
                paramDestination.Value = flight.Destination;
                command.Parameters.Add(paramDestination);

                /*var paramDepartureDate = command.CreateParameter();
                paramDepartureDate.ParameterName = "@departure";
                paramDepartureDate.Value = flight.DepartureDate;
                command.Parameters.Add(paramDepartureDate);*/

                var paramAirport = command.CreateParameter();
                paramAirport.ParameterName = "@airport";
                paramAirport.Value = flight.Airport;
                command.Parameters.Add(paramAirport);

                var paramSeats = command.CreateParameter();
                paramSeats.ParameterName = "@seats";
                paramSeats.Value = flight.NumberOfAvailablePlaces;
                command.Parameters.Add(paramSeats);

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Update - No flight updated");
                    throw new RepositoryException("No flight updated!");
                }
            }
            log.InfoFormat("Exiting Update - Flight updated successfully");
        }

        public IEnumerable<Flight> FindAll()
        {
            log.InfoFormat("Entering FindAll");
            IDbConnection connection = DBUtils.GetConnection();
            IList<Flight> all = new List<Flight>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from flights";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string destination = dataReader.GetString(1);
                        String depDate = dataReader.GetString(2);
                      //  long timeStampMilliSeconds = dataReader.GetInt64(2);
                        // DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        // DateTime departureDate = start.AddMilliseconds(timeStampMilliSeconds).ToLocalTime();
                        //DateTime departureDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timeStampMilliSeconds).ToLocalTime();
                        DateTime dateTime = DateTime.Parse(depDate);
                        string airport = dataReader.GetString(3);
                        int seats = dataReader.GetInt32(4);
                        Flight flight = new Flight(destination, dateTime, airport, seats);
                        flight.ID = id;
                        all.Add(flight);
                    }
                }
            }
            log.InfoFormat("Exiting FindAll");
            return all;
        }

        public List<Flight> FindByDestinationAndDepartureDate(string destination, DateTime departureDate)
        {
            log.InfoFormat("Entering FindByDestinationAndDepartureDate");
            IDbConnection connection = DBUtils.GetConnection();
            List<Flight> filtered = new List<Flight>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from flights where destination=@destination and departure between @departureStart and @departureEnd";
                IDbDataParameter paramDestination = command.CreateParameter();
                paramDestination.ParameterName = "@destination";
                paramDestination.Value = destination;
                command.Parameters.Add(paramDestination);

                DateTime baseDate = new DateTime(1970, 01, 01, 0, 0, 0);
                DateTime departureDateStart = new DateTime(departureDate.Year, departureDate.Month, departureDate.Day, 0, 0, 0);
                DateTime departureDateEnd = new DateTime(departureDate.Year, departureDate.Month, departureDate.Day, 23, 59, 59);

                var timeStampStart = departureDateStart.Subtract(baseDate).TotalMilliseconds;
                var timeStampEnd = departureDateEnd.Subtract(baseDate).TotalMilliseconds;

                String start = departureDateStart.ToString("yyyy-MM-dd HH:mm:ss");
                String end = departureDateEnd.ToString("yyyy-MM-dd HH:mm:ss");

                IDbDataParameter paramDepartureStart = command.CreateParameter();
                paramDepartureStart.ParameterName = "@departureStart";
                paramDepartureStart.Value = start;
                command.Parameters.Add(paramDepartureStart);
                

                IDbDataParameter paramDepartureEnd = command.CreateParameter();
                paramDepartureEnd.ParameterName = "@departureEnd";
                paramDepartureEnd.Value = end;
                command.Parameters.Add(paramDepartureEnd);

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string destinationDb = dataReader.GetString(1);
                        //long timeStampMilliSeconds = dataReader.GetInt64(2);
                        //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        //DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
                        //dtDateTime = dtDateTime.AddSeconds( dataReader.GetDateTime(2)).ToLocalTime();
                        //DateTime departureDateTime = dataReader.get(3);
                        String datee = dataReader.GetString(2);
                        DateTime dateTime = DateTime.Parse(datee);
                        string airport = dataReader.GetString(3);
                        int seats = dataReader.GetInt32(4);
                        Flight flight = new Flight(destinationDb, dateTime, airport, seats);
                        flight.ID = id;
                        if (seats > 0) filtered.Add(flight);
                    }
                }
            }
            log.InfoFormat("Exiting FindByDestinationAndDepartureDate");
            return filtered;
        }
        
    }
}
