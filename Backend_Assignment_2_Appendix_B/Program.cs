using Backend_Assignment_2_Appendix_B.DataAccess;
using Backend_Assignment_2_Appendix_B.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment_2_Appendix_B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Test run for all the methods with some random inputs in the methods
             */


            ICustomerRepository repo = new CustomerRepository();


            Console.WriteLine("*************************************************************************************************************************\n " +
                "2.1 Read all customers\n");

            List<Customer> customers = repo.GetAllCustomers();

            customers.ForEach(x => Console.WriteLine(x));


            Console.WriteLine("\n*************************************************************************************************************************\n " +
                "2.2 Read customer by id\n");

            Console.WriteLine(repo.GetCustomer(1));


            Console.WriteLine("\n********************************************************************************************************************\n " +
               "2.3 Read customer by name\n");

            repo.GetCustomer("Robert").ForEach(c => Console.WriteLine(c));


            Console.WriteLine("\n********************************************************************************************************************\n " +
               "2.4 Read a page of customers by offset=5 and limit=10\n");

            repo.GetCustomerPage(5, 10).ForEach(c => Console.WriteLine(c));


            Console.WriteLine("\n********************************************************************************************************************\n " +
               "2.5 Add a new customer\n");

            Customer customer = new Customer();
            customer.FirstName = "Bob";
            customer.LastName = "Bobsen";
            customer.Country = "USA";
            customer.PostalCode = "5018";
            customer.Phone = "12355123";
            customer.Email = "bob@hotmail.com";

            repo.AddCustomer(customer);
            repo.GetCustomer("Bob Bobsen").ForEach(c => Console.WriteLine(c));

            Console.WriteLine("\n********************************************************************************************************************\n " +
               "2.6 Update a customer\n");

            customer.FirstName = "Bob";
            customer.LastName = "Bobsen";
            customer.Country = "USA";
            customer.PostalCode = "1235";
            customer.Phone = "93434931";
            customer.Email = "bob@outlook.com";

            repo.UpdateCustomer("Bob Bobsen", customer);
            repo.GetCustomer("Bob Bobsen").ForEach(c => Console.WriteLine(c));


            Console.WriteLine("\n********************************************************************************************************************\n " +
               "2.7 Get number of customers in each country \n");

            List<CustomerCountry> countries = repo.GetNumberOfCustomersInCountry();
            countries.ForEach(country => Console.WriteLine(country));


            Console.WriteLine("\n********************************************************************************************************************\n " +
               "2.8 Get highest spender \n");

            List<CustomerSpender> spenders = repo.GetHighestSpenders();
            spenders.ForEach(spender => Console.WriteLine(spender));


            Console.WriteLine("\n********************************************************************************************************************\n " +
               "2.8 Get most popular genre for a given customer \n");


            CustomerGenre genre = repo.GetMostPopularGenre(12);
            Console.WriteLine(genre.ToString());
            genre = repo.GetMostPopularGenre(16);
            Console.WriteLine(genre.ToString());


            Console.ReadKey();
        }
    }
}
