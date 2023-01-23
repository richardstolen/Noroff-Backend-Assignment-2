
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
                                    Customer temp = new Customer();
                                    temp.CustomerId = reader.GetInt32(0);
                                    temp.FirstName = reader.GetString(1);
                                    temp.LastName = reader.GetString(2);
                                    temp.Country = reader.GetString(7);
                                    temp.PostalCode = reader.GetString(8);
                                    temp.Phone = reader.GetString(9);
                                    temp.Email = reader.GetString(11);
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
                                    customer.CustomerId = reader.GetInt32(0);
                                    customer.FirstName = reader.GetString(1);
                                    customer.LastName = reader.GetString(2);
                                    customer.Country = reader.GetString(7);
                                    customer.PostalCode = reader.GetString(8);
                                    customer.Phone = reader.GetString(9);
                                    customer.Email = reader.GetString(11);
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
                    cmd.Parameters.AddWithValue("Name", name);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    Customer temp = new Customer();
                                    temp.CustomerId = reader.GetInt32(0);
                                    temp.FirstName = reader.GetString(1);
                                    temp.LastName = reader.GetString(2);
                                    temp.Country = reader.GetString(7);
                                    temp.PostalCode = reader.GetString(8);
                                    temp.Phone = reader.GetString(9);
                                    temp.Email = reader.GetString(11);
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
    }
}
