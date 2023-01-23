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

            List<Customer> customers = repo.GetAllCustomers();

            customers.ForEach(x => Console.WriteLine(x));

            //Console.WriteLine(repo.GetCustomer(2));
        }
    }
}
