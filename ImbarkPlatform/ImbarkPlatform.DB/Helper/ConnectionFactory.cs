using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImbarkPlatform.DB.Helper
{
    public class ConnectionFactory
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;// "Data Source=S-NB-009;Initial Catalog=LsracingData;uid=sa;pwd=Stellar123";

        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public static DBConnection GetConnection()
        {
            return DBConnection.GetConnection(ConnectionString);
        }

        //获取无事务的操作
        public static DBConnection GetConnectionNoTran()
        {
            return DBConnection.GetConnectionNoTran(ConnectionString);
        }
    }
}
