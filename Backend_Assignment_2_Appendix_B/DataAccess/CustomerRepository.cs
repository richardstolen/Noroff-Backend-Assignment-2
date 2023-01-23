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
                                    Customer temp = SqlHelper.getCustomerWithSpecificColumns(reader);

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

            string sql = "SELECT * FROM [Customer] WHERE [CustomerId]=@Id";

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
                                    customer = SqlHelper.getCustomerWithSpecificColumns(reader);
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

            string sql =
                "SELECT * FROM [Customer]" +
                "WHERE [FirstName] + ' ' + [LastName] LIKE '%' + @Name + '%'";

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
                                    Customer temp = SqlHelper.getCustomerWithSpecificColumns(reader);
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

            string sql =
                "SELECT * FROM [Customer] " +
                "ORDER BY [CustomerId]" +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";

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
                                    Customer temp = SqlHelper.getCustomerWithSpecificColumns(reader);
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

        public bool AddCustomer(Customer customer)
        {
            bool success = false;

            string fullname = customer.FirstName + " " + customer.LastName;
            List<Customer> checkIfExists = GetCustomer(fullname);

            if (checkIfExists.Count > 0)
            {
                Console.WriteLine("Customer already exists!");
                return false;
            }

            string sql =
                "INSERT INTO [Customer] ([FirstName], [LastName], [Country], [PostalCode], [Phone], [Email])" +
                "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("Country", customer.Country);
                    cmd.Parameters.AddWithValue("PostalCode", customer.PostalCode);
                    cmd.Parameters.AddWithValue("Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("Email", customer.Email);

                    try
                    {
                        conn.Open();

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            success = true;
                            Console.WriteLine($"Success, {affectedRows} rows affected");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return success;
        }

        public bool UpdateCustomer(string existingName, Customer customer)
        {
            bool success = false;


            List<Customer> checkIfExists = GetCustomer(existingName);

            if (checkIfExists.Count == 0)
            {
                Console.WriteLine("Customer does not exist!");
                return false;
            }

            string sql =
                "UPDATE [Customer] " +
                "SET [FirstName]=@FirstName, [LastName]=@LastName, [Country]=@Country, " +
                "[PostalCode]=@PostalCode, [Phone]=@Phone, [Email]=@Email " +
                "WHERE [FirstName] + ' ' + [LastName] = @ExistingName";

            using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("ExistingName", existingName);
                    cmd.Parameters.AddWithValue("FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("Country", customer.Country);
                    cmd.Parameters.AddWithValue("PostalCode", customer.PostalCode);
                    cmd.Parameters.AddWithValue("Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("Email", customer.Email);

                    try
                    {
                        conn.Open();

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            success = true;
                            Console.WriteLine($"Success, {affectedRows} rows affected");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return success;
        }
    }
}
