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
            ICustomerRepository repo = new CustomerRepository();

            Customer customer = new Customer();
            customer.FirstName = "Per";
            customer.LastName = "Persen";
            customer.Country = "Norway";
            customer.PostalCode = "5018";
            customer.Phone = "99340437";
            customer.Email = "richlones@hotmail.com";

            //repo.AddCustomer(customer);

            //repo.UpdateCustomer("Per Persen", customer);

            List<Customer> customers = repo.GetAllCustomers();

            //customers.ForEach(x => Console.WriteLine(x));

            foreach (Customer customer2 in customers)
            {
                CustomerGenre genre = repo.GetMostPopularGenre(customer2.CustomerId);
                Console.WriteLine(genre.ToString());

            }

            //Console.WriteLine(repo.GetCustomer("Robert"));

            //List<CustomerCountry> countries = repo.GetNumberOfCustomersInCountry();
            //countries.ForEach(country => Console.WriteLine(country));

            //List<CustomerSpender> spenders = repo.GetHighestSpenders();
            //spenders.ForEach(spender => Console.WriteLine(spender));


            // genres.Genres.ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
}
