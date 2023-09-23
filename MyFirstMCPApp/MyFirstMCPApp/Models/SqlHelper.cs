using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MyFirstMCPApp.Models
{
    public class SqlHelper
    {
        public static SqlConnection CreateConnection()  //CreateConnection-->Connection factor;an example of factory method.
        {
            var connString = @"server=200411LTP2857\SQLEXPRESS;database=testdb;integrated security=true;Encrypt=false";
            SqlConnection sqlcn = new SqlConnection(connString);
            return sqlcn;
        }
    }
}
