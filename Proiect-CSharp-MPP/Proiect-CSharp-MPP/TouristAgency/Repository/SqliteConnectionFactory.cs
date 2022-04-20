using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Npgsql;

namespace Persistence
{
    public class PostgresConnectionFactory : ConnectionFactory
    {
        public override NpgsqlConnection CreateConnection()
        {
            string cs = "Host=localhost;Username=postgres;Password=paula123;Database=tourism-agency-c";
            //  string connectionString = "Data Source:jdbc:postgresql://localhost:5432/tourism-agency-c";
            return new NpgsqlConnection(cs);
        }

    }
}
