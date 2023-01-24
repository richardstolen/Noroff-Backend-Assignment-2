using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend_Assignment_2_Appendix_B.Model;
using Microsoft.Data.SqlClient;

namespace Backend_Assignment_2_Appendix_B.DataAccess
{
    internal class SqlHelper
    {
        public static string ConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-SQ77T5G\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }

        public static Customer GetCustomerWithSpecificColumns(SqlDataReader reader)
        {
            Customer customer = new Customer();

            customer.CustomerId = reader.GetInt32(0);
            customer.FirstName = reader.IsDBNull(1) ? "null" : reader.GetString(1);
            customer.LastName = reader.IsDBNull(2) ? "null" : reader.GetString(2);
            customer.Country = reader.IsDBNull(7) ? "null" : reader.GetString(7);
            customer.PostalCode = reader.IsDBNull(8) ? "null" : reader.GetString(8);
            customer.Phone = reader.IsDBNull(9) ? "null" : reader.GetString(9);
            customer.Email = reader.IsDBNull(11) ? "null" : reader.GetString(11);

            return customer;
        }
    }
}
