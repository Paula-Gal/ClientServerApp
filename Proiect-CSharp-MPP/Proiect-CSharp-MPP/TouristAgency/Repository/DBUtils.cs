using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Persistence
{
    public static class DBUtils
    {
        private static NpgsqlConnection instance = null;

        public static NpgsqlConnection GetConnection()
        {
            if(instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = GetNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static NpgsqlConnection GetNewConnection()
        {
            return ConnectionFactory.GetInstance().CreateConnection();
        }
    }
}
