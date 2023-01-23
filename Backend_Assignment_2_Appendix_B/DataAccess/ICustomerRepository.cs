using Backend_Assignment_2_Appendix_B.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment_2_Appendix_B.DataAccess
{
    interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        List<Customer> GetCustomer(string name);
        List<Customer> GetCustomerPage(int limit, int offset);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(string existingName, Customer customer);
    }
}
