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
            customer.FirstName = "Richard";
            customer.LastName = "Stolen";
            customer.Country = "Norway";
            customer.PostalCode = "5018";
            customer.Phone = "99340437";
            customer.Email = "richlones@hotmail.com";

            repo.AddCustomer(customer);

            List<Customer> customers = repo.GetCustomer("Rober");

            customers.ForEach(x => Console.WriteLine(x));

            //Console.WriteLine(repo.GetCustomer("Robert"));
        }
    }
}
