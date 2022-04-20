using Npgsql;
using Proiect_CSharp_MPP.TouristAgency.Repository;

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
