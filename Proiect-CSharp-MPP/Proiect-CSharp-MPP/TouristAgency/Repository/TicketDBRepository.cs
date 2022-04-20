using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data;
using Model.Domain;


namespace Persistence
{
    class TicketDBRepository : ITicketRepository
    {
        private static readonly ILog log = LogManager.GetLogger("TicketDBRepository");
        public TicketDBRepository()
        {
            log.Info("Creating TicketDBRepository");
        }

        private Customer FindCustomer(int id)
        {
            log.InfoFormat("Entering FindCustomer with value {0}", id);
            IDbConnection con = DBUtils.GetConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from customers where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataReader = comm.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        string name = dataReader.GetString(1);
                        string cnp = dataReader.GetString(2);
                        string address = dataReader.GetString(3);
                        Customer customer = new Customer(name, cnp, address);
                        customer.ID = id;
                        log.InfoFormat("Exiting FindCustomer with value {0}", customer);
                        return customer;
                    }
                }
            }
            log.InfoFormat("Exiting FindCustomer with value {0}", null);
            return null;
        }

        private Flight FindFlight(int id)
        {
            log.InfoFormat("Entering FindFlight with value {0}", id);
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
                        DateTime departureDate = dataReader.GetDateTime(2);
                        string airport = dataReader.GetString(3);
                        int seats = dataReader.GetInt32(4);
                        Flight flight = new Flight(destination, departureDate, airport, seats);
                        flight.ID = id;
                        log.InfoFormat("Exiting FindFlight with value {0}", flight);
                        return flight;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public Ticket FindOne(int id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
            IDbConnection con = DBUtils.GetConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from tickets where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataReader = comm.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int customerId = dataReader.GetInt32(1);
                        int flightId = dataReader.GetInt32(2);
                        int seats = dataReader.GetInt32(3);
                        string touristsString = dataReader.GetString(4);
                        Customer customer = FindCustomer(customerId);
                        Flight flight = FindFlight(flightId);
                        string[] touristsStr = touristsString.Split(';');
                        List<string> tourists = new List<string>();
                        foreach(string t in touristsStr)
                        {
                            tourists.Add(t);
                        }
                        Ticket ticket = new Ticket(customer, tourists, seats, flight);
                        ticket.ID = id;
                        log.InfoFormat("Exiting FindOne with value {0}", ticket);
                        return ticket;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public void Add(Ticket ticket)
        {
            log.InfoFormat("Entering Add with value {0}", ticket);
            IDbConnection connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into tickets(id_customer, id_flight, seats, tourists) values(@id_customer, @id_flight, @seats, @tourists)";

                var paramCustomerId = command.CreateParameter();
                paramCustomerId.ParameterName = "@id_customer";
                paramCustomerId.Value = ticket.Customer.ID;
                command.Parameters.Add(paramCustomerId);

                var paramFlightId = command.CreateParameter();
                paramFlightId.ParameterName = "@id_flight";
                paramFlightId.Value = ticket.Flight.ID;
                command.Parameters.Add(paramFlightId);

                var paramSeats = command.CreateParameter();
                paramSeats.ParameterName = "@seats";
                paramSeats.Value = ticket.NumberOfPlaces;
                command.Parameters.Add(paramSeats);

                List<string> tourists = new List<string>();
                tourists = ticket.Tourists;
                string touristsString = tourists.Aggregate("", (x, y) => x + ";" + y);
                var paramTourists = command.CreateParameter();
                paramTourists.ParameterName = "@tourists";
                paramTourists.Value = touristsString;
                command.Parameters.Add(paramTourists);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Add - No customer added");
                    throw new RepositoryException("No customer added!");
                }
            }
            log.InfoFormat("Exiting Add - Customer added successfully");
        }

        public void Delete(Ticket ticket)
        {
            log.InfoFormat("Entering Delete with value {0}", ticket);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from tickets where id=@id";
                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ticket.ID;
                command.Parameters.Add(paramId);
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting add - No ticket deleted");
                    throw new RepositoryException("No ticket deleted!");
                }
            }
            log.InfoFormat("Exiting Delete - Ticket deleted successfully");
        }

        public void Update(Ticket ticket, int id)
        {
            log.InfoFormat("Entering Update with values {0}, {1}", ticket, id);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update Tickets set id_customer=@id_customer, id_flight=@id_flight, seats=@seats, tourists=@tourists where id=@id";
                var paramCustomerId = command.CreateParameter();
                paramCustomerId.ParameterName = "@id_customer";
                paramCustomerId.Value = ticket.Customer.ID;
                command.Parameters.Add(paramCustomerId);

                var paramFlightId = command.CreateParameter();
                paramFlightId.ParameterName = "@id_flight";
                paramFlightId.Value = ticket.Flight.ID;
                command.Parameters.Add(paramFlightId);

                var paramSeats = command.CreateParameter();
                paramSeats.ParameterName = "@seats";
                paramSeats.Value = ticket.NumberOfPlaces;
                command.Parameters.Add(paramSeats);

                List<string> tourists = new List<string>();
                tourists = ticket.Tourists;
                string touristsString = tourists.Aggregate("", (x, y) => x + ";" + y);
                var paramTourists = command.CreateParameter();
                paramTourists.ParameterName = "@tourists";
                paramTourists.Value = touristsString;
                command.Parameters.Add(paramTourists);

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Update - No ticket updated");
                    throw new RepositoryException("No ticket updated!");
                }
            }
            log.InfoFormat("Exiting Update - Ticket updated successfully");
        }

        public IEnumerable<Ticket> FindAll()
        {
            log.InfoFormat("Entering FindAll");
            IDbConnection connection = DBUtils.GetConnection();
            IList<Ticket> all = new List<Ticket>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Tickets";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        int customerId = dataReader.GetInt32(1);
                        int flightId = dataReader.GetInt32(2);
                        int seats = dataReader.GetInt32(3);
                        string touristsString = dataReader.GetString(4);
                        Customer customer = FindCustomer(customerId);
                        Flight flight = FindFlight(flightId);
                        string[] touristsStr = touristsString.Split(';');
                        List<string> tourists = new List<string>();
                        foreach (string t in touristsStr)
                        {
                            tourists.Add(t);
                        }
                        Ticket ticket = new Ticket(customer, tourists, seats, flight);
                        ticket.ID = id;
                        all.Add(ticket);
                    }
                }
            }
            log.InfoFormat("Exiting FindAll");
            return all;
        }
        
    }
}
