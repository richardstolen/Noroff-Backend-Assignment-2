﻿using Backend_Assignment_2_Appendix_B.Model;
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
        /// <summary>
        /// Method to get all customers in the database
        /// </summary>
        /// <returns>List of customers</returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string sql = "SELECT * FROM [Customer]";

            GetListsFunc<Customer> func = (SqlDataReader reader) =>
            {
                // Using helper method to select what columns to add
                // Helper method reads from database and returns a Customer object
                Customer temp = SqlHelper.GetCustomerWithSpecificColumns(reader);

                customers.Add(temp);

                return customers;
            };

            customers = GetLists(func, customers, sql);

            return customers;
        }

        /// <summary>
        /// Get Customer with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Customer object</returns>
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();

            string sql = "SELECT * FROM [Customer] WHERE [CustomerId]=@Id";

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString()))
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
                                    // Using helper method to select what columns to add
                                    // Helper method reads from database and return a Customer object
                                    customer = SqlHelper.GetCustomerWithSpecificColumns(reader);
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

        /// <summary>
        /// Method to get a customer with name. 
        /// Also returns partial matches
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of customers that match the input</returns>
        public List<Customer> GetCustomer(string name)
        {
            List<Customer> customers = new List<Customer>();

            string sql =
                "SELECT * FROM [Customer]" +
                "WHERE [FirstName] + ' ' + [LastName] LIKE '%' + @Name + '%'";

            GetListsWithParametersFunc<Customer> func = (SqlDataReader reader) =>
            {
                // Using helper method to select what columns to add
                // Helper method reads from database and return a Customer object
                Customer temp = SqlHelper.GetCustomerWithSpecificColumns(reader);
                customers.Add(temp);

                return customers;
            };

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("Name", name);

            customers = GetListsWithParameters(func, customers, sql, cmd);

            return customers;
        }

        /// <summary>
        /// Method to get a subset of customers wth offset and limit.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>List of customers</returns>
        public List<Customer> GetCustomerPage(int offset, int limit)
        {
            List<Customer> customers = new List<Customer>();

            string sql =
                "SELECT * FROM [Customer] " +
                "ORDER BY [CustomerId]" +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";

            GetListsWithParametersFunc<Customer> func = (SqlDataReader reader) =>
            {
                // Using helper method to select what columns to add
                // Helper method reads from database and returns a Customer object
                Customer temp = SqlHelper.GetCustomerWithSpecificColumns(reader);

                customers.Add(temp);

                return customers;
            };

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("Offset", offset);
            cmd.Parameters.AddWithValue("Limit", limit);

            customers = GetListsWithParameters(func, customers, sql, cmd);

            return customers;
        }

        /// <summary>
        /// Adds a customer to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
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

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString()))
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

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="existingName"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
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

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString()))
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

        /// <summary>
        /// Returns number of customers in each country, ordered descending
        /// </summary>
        /// <returns>List of CustomerCountry objects</returns>
        public List<CustomerCountry> GetNumberOfCustomersInCountry()
        {
            List<CustomerCountry> countries = new List<CustomerCountry>();

            string sql =
                "SELECT [Country], COUNT(*) AS 'NumberOfCustomers'" +
                "FROM [Customer]" +
                "GROUP BY [Country]";

            GetListsFunc<CustomerCountry> func = (SqlDataReader reader) =>
            {
                CustomerCountry temp = new CustomerCountry();

                temp.Country = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                temp.NumberOfCustomers = reader.IsDBNull(1) ? -1 : reader.GetInt32(1);
                countries.Add(temp);

                return countries;
            };

            countries = GetLists(func, countries, sql);

            return countries.OrderByDescending(x => x.NumberOfCustomers).ToList();
        }

        /// <summary>
        /// A method to get the highest spenders (total in invoice table).
        /// Ordered descending
        /// </summary>
        /// <returns>List of CustomerSpender objects</returns>
        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> spenders = new List<CustomerSpender>();

            string sql =
                "SELECT [Customer].[CustomerId], Sum([Invoice].[Total]) AS 'Total'" +
                "FROM [Invoice] " +
                "INNER JOIN [Customer] ON [Invoice].[CustomerId] = [Customer].[CustomerID]" +
                "GROUP BY [Customer].[CustomerId]";

            GetListsFunc<CustomerSpender> func = (SqlDataReader reader) =>
            {
                CustomerSpender temp = new CustomerSpender();

                temp.Customer = GetCustomer(reader.IsDBNull(0) ? -1 : reader.GetInt32(0));
                temp.Total = reader.IsDBNull(1) ? new Decimal(-1) : reader.GetDecimal(1);
                spenders.Add(temp);

                return spenders;
            };

            spenders = GetLists(func, spenders, sql);

            return spenders.OrderByDescending(x => x.Total).ToList();
        }

        public CustomerGenre GetMostPopularGenre(int id)

        {
            CustomerGenre customerGenre = new CustomerGenre();

            Customer customer = GetCustomer(id);

            string sql =
                "SELECT Genre.Name, COUNT(Genre.Name) AS 'count'" +
                "FROM [Customer]" +
                "INNER JOIN [Invoice] ON [Invoice].[CustomerId] = [Customer].[CustomerId]" +
                "INNER JOIN [InvoiceLine] ON [InvoiceLine].[InvoiceId] = [Invoice].[InvoiceId]" +
                "INNER JOIN [Track] ON [Track].[TrackId] = [InvoiceLine].[TrackId]" +
                "INNER JOIN [Genre] ON [Genre].[GenreId] = [Track].[GenreId]" +
                "WHERE [Customer].[CustomerId] = @CustomerId " +
                "GROUP BY Genre.Name " +
                "ORDER BY 'count' DESC";


            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("CustomerId", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    customerGenre.Customer = customer;

                                    string genre = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                                    int count = reader.IsDBNull(1) ? -1 : reader.GetInt32(1);

                                    customerGenre.Genres.Add(genre, count);
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

            return customerGenre;
        }

        //List<Customer> customers = new List<Customer>();

        //string sql =
        //    "SELECT * FROM [Customer] " +
        //    "ORDER BY [CustomerId]" +
        //    "OFFSET @Offset ROWS " +
        //    "FETCH NEXT @Limit ROWS ONLY";

        //GetListsWithParametersFunc<Customer> func = (SqlDataReader reader) =>
        //{
        //    // Using helper method to select what columns to add
        //    // Helper method reads from database and returns a Customer object
        //    Customer temp = SqlHelper.GetCustomerWithSpecificColumns(reader);

        //    customers.Add(temp);

        //    return customers;
        //};

        //SqlCommand cmd = new SqlCommand();

        //cmd.Parameters.AddWithValue("Offset", offset);
        //    cmd.Parameters.AddWithValue("Limit", limit);

        //    customers = GetListsWithParameters(func, customers, sql, cmd);

        //    return customers;











        public delegate List<T> GetListsFunc<T>(SqlDataReader reader);
        public delegate List<T> GetListsWithParametersFunc<T>(SqlDataReader reader);

        public List<T> GetLists<T>(GetListsFunc<T> function, List<T> list, string sql)
        {

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString()))
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
                                    list = function(reader);
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

            return list;
        }

        public List<T> GetListsWithParameters<T>(GetListsWithParametersFunc<T> function, List<T> list, string sql, SqlCommand sqlCommand)
        {

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();

                        foreach (SqlParameter para in sqlCommand.Parameters)
                        {
                            cmd.Parameters.AddWithValue(para.ParameterName, para.Value);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    list = function(reader);
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

            return list;
        }

    } // Class
}
