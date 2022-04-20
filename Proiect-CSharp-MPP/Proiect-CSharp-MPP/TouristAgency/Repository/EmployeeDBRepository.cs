using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using log4net;
using System.Data;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Persistence
{
     class EmployeeDBRepository : IEmployeeRepository
    {
        private static readonly ILog log = LogManager.GetLogger("EmployeeDBRepository");

        public EmployeeDBRepository()
        {
            log.Info("Creating EmployeeDBRepository");
        }

        public Employee FindOne(int id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
            IDbConnection con = DBUtils.GetConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from employees where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataReader = comm.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        string username = dataReader.GetString(1);
                        string password = dataReader.GetString(2);
                        Employee employee = new Employee(username, password);
                        employee.ID = id;
                        log.InfoFormat("Exiting FindOne with value {0}", employee);
                        return employee;
                    }
                }
            }

            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public void Add(Employee employee)
        {
            log.InfoFormat("Entering Add with value {0}", employee);
            IDbConnection connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into employees(name, username, password) values(@name, @username, @password)";

                var paramUsername = command.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = employee.Username;
                command.Parameters.Add(paramUsername);

                var paramPassword = command.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = employee.Password;
                command.Parameters.Add(paramPassword);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Add - No employee added");
                    throw new RepositoryException("No employee added!");
                }
            }

            log.InfoFormat("Exiting Add - Employee added successfully");
        }

        public void Delete(Employee employee)
        {
            log.InfoFormat("Entering Delete with value {0}", employee);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from employees where id=@id";
                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = employee.ID;
                command.Parameters.Add(paramId);
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting add - No employee deleted");
                    throw new RepositoryException("No employee deleted!");
                }
            }

            log.InfoFormat("Exiting Delete - Employee deleted successfully");
        }

        public void Update(Employee employee, int id)
        {
            log.InfoFormat("Entering Update with values {0}, {1}", employee, id);
            var connection = DBUtils.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update employees set name=@name, username=@username, password=@password where id=@id";

                var paramUsername = command.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = employee.Username;
                command.Parameters.Add(paramUsername);

                var paramPassword = command.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = employee.Password;
                command.Parameters.Add(paramPassword);

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Update - No employee updated");
                    throw new RepositoryException("No employee updated!");
                }
            }

            log.InfoFormat("Exiting Update - Employee updated successfully");
        }

        public IEnumerable<Employee> FindAll()
        {
            log.InfoFormat("Entering FindAll");
            IDbConnection connection = DBUtils.GetConnection();
            IList<Employee> all = new List<Employee>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from employees";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string username = dataReader.GetString(1);
                        string password = dataReader.GetString(2);
                        Employee employee = new Employee(username, password);
                        employee.ID = id;
                        all.Add(employee);
                    }
                }
            }

            log.InfoFormat("Exiting FindAll");
            return all;
        }

        public Employee FindByUsername(string username)
        {
            log.InfoFormat("Entering FindByUsername with value {0}", username);
            IDbConnection con = DBUtils.GetConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from employees where username=@username";
                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);

                using (var dataReader = comm.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string usename = dataReader.GetString(1);
                        string password = dataReader.GetString(2);
                        Employee employee = new Employee(usename, password);
                        employee.ID = id;
                        log.InfoFormat("Exiting FindOne with value {0}", employee);
                        return employee;
                    }
                }
            }
            log.InfoFormat("Exiting FindByUsername with value {0}", null);
            return null;
        }
    }
}
