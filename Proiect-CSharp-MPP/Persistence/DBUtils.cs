using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Proiect_CSharp_MPP.TouristAgency.Repository;

namespace Persistence
{
    public static class DBUtils
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection()
        {
            if(instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = GetNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection GetNewConnection()
        {
            return ConnectionFactory.GetInstance().CreateConnection();
        }
    }
}
