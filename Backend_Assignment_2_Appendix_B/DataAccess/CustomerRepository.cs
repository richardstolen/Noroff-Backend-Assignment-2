
using Backend_Assignment_2_Appendix_B.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
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


                            }

                        }
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

                            }
                        }
                    }
                }
            }

            return customer;
        }

        public Customer GetCustomer(string name)
        {
            Customer customer = new Customer();

            string sql = "SELECT * FROM [Customer] WHERE CustomerId=@Id";

            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString()))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);

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

                            }
                        }
                    }
                }
            }

            return customer;
        }
    }
}
