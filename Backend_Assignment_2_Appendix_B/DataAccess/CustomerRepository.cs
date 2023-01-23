
using Backend_Assignment_2_Appendix_B.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Backend_Assignment_2_Appendix_B.DataAccess
{
    internal class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string sql = "SELECT * FROM [Customer]";

            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString()))
            {

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    Customer temp = getCustomerWithSpecificColumns(reader);

                                    customers.Add(temp);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();

            string sql = "SELECT * FROM [Customer] WHERE CustomerId=@Id";

            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString()))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    customer = getCustomerWithSpecificColumns(reader);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }


                }
            }

            return customer;
        }

        public List<Customer> GetCustomer(string name)
        {
            List<Customer> customers = new List<Customer>();

            string sql = "SELECT * FROM [Customer]" +
                "WHERE FirstName LIKE '%' + @name + '%' OR LastName LIKE '%' + @name + '%'";

            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("name", name);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    Customer temp = getCustomerWithSpecificColumns(reader);
                                    customers.Add(temp);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return customers;
        }

        public List<Customer> GetCustomerPage(int offset, int limit)
        {
            List<Customer> customers = new List<Customer>();

            string sql = "SELECT * FROM [Customer] ORDER BY [CustomerId]" +
                "OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";

            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("Offset", offset);
                    cmd.Parameters.AddWithValue("Limit", limit);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    Customer temp = getCustomerWithSpecificColumns(reader);
                                    customers.Add(temp);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return customers;
        }


        public static Customer getCustomerWithSpecificColumns(SqlDataReader reader)
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
