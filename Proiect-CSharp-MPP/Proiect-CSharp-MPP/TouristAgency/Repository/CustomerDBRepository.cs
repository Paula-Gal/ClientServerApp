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
     class CustomerDBRepository : ICustomerRepository
    {
        private static readonly ILog log = LogManager.GetLogger("CustomerDBRepository");
        public CustomerDBRepository()
        {
            log.Info("Creating CustomerDBRepository");
        }
        public Customer FindOne(int id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
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
                    if(dataReader.Read())
                    {
                        string name = dataReader.GetString(1);
                        string cnp = dataReader.GetString(2);
                        string address = dataReader.GetString(3);
                        Customer customer = new Customer(name, cnp, address);
                        customer.ID = id;
                        log.InfoFormat("Exiting FindOne with value {0}", customer);
                        return customer;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public void Add(Customer customer)
        {
            log.InfoFormat("Entering Add with value {0}", customer);
            IDbConnection connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into customers(name, cnp, address) values(@name, @CNP, @address)";
                
                var paramName = command.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = customer.Name;
                command.Parameters.Add(paramName);

                var paramCnp = command.CreateParameter();
                paramCnp.ParameterName = "@CNP";
                paramCnp.Value = customer.CNP;
                command.Parameters.Add(paramCnp);

                var paramAddress = command.CreateParameter();
                paramAddress.ParameterName = "@address";
                paramAddress.Value = customer.Address;
                command.Parameters.Add(paramAddress);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Add - No customer added");
                    throw new RepositoryException("No customer added!");
                }
            }
            log.InfoFormat("Exiting Add - Customer added successfully");
        }

        public void Delete(Customer customer)
        {
            log.InfoFormat("Entering Delete with value {0}", customer);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from customers where id=@id";
                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = customer.ID;
                command.Parameters.Add(paramId);
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting add - No customer deleted");
                    throw new RepositoryException("No customer deleted!");
                }
            }
            log.InfoFormat("Exiting Delete - Customer deleted successfully");
        }

        public void Update(Customer customer, int id)
        {
            log.InfoFormat("Entering Update with values {0}, {1}", customer, id);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update customers set name=@name, cnp=@CNP, address=@address where id=@id";
                var paramName = command.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = customer.Name;
                command.Parameters.Add(paramName);

                var paramCnp = command.CreateParameter();
                paramCnp.ParameterName = "@CNP";
                paramCnp.Value = customer.CNP;
                command.Parameters.Add(paramCnp);

                var paramAddress = command.CreateParameter();
                paramAddress.ParameterName = "@address";
                paramAddress.Value = customer.Address;
                command.Parameters.Add(paramAddress);

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Update - No customer updated");
                    throw new RepositoryException("No customer updated!");
                }
            }
            log.InfoFormat("Exiting Update - Customer updated successfully");
        }

        public IEnumerable<Customer> FindAll()
        {
            log.InfoFormat("Entering FindAll");
            IDbConnection connection = DBUtils.GetConnection();
            IList<Customer> all = new List<Customer>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from customers";
                using (var dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string name = dataReader.GetString(1);
                        string cnp = dataReader.GetString(2);
                        string address = dataReader.GetString(3);
                        Customer customer = new Customer(name, cnp, address);
                        customer.ID = id;
                        all.Add(customer);
                    }
                }
            }
            log.InfoFormat("Exiting FindAll");
            return all;
        }

        public Customer FindByCnp(string cnp)
        {
            log.InfoFormat("Entering FindByCnp with value {0}", cnp);
            IDbConnection con = DBUtils.GetConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from customers where cnp=@cnp";
                IDbDataParameter paramCnp = comm.CreateParameter();
                paramCnp.ParameterName = "@cnp";
                paramCnp.Value = cnp;
                comm.Parameters.Add(paramCnp);

                using (var dataReader = comm.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string name = dataReader.GetString(1);
                        string address = dataReader.GetString(3);
                        Customer customer = new Customer(name, cnp, address);
                        customer.ID = id;
                        log.InfoFormat("Exiting FindByCnp with value {0}", customer);
                        return customer;
                    }
                }
            }
            log.InfoFormat("Exiting FindByCnp with value {0}", null);
            return null;
        }
    }
}
