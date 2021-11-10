using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Connection
    {

        public static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Connection"].ToString();

        }
    }
}
