﻿using Backend_Assignment_2_Appendix_B.DataAccess;
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

            //repo.UpdateCustomer("Pål Pålsen", customer);

            List<Customer> customers = repo.GetAllCustomers();

            foreach (var item in customers)
            {
                Console.WriteLine(repo.GetMostPopularGenre(item.CustomerId));
            }

            //List<Customer> getCustomerName = repo.GetCustomer("Robert");
            //getCustomerName.ForEach(x => Console.WriteLine(x));


            //List<CustomerCountry> countries = repo.GetNumberOfCustomersInCountry();
            //countries.ForEach(country => Console.WriteLine(country));

            //List<CustomerSpender> spenders = repo.GetHighestSpenders();
            //spenders.ForEach(spender => Console.WriteLine(spender));
        }
    }
}
