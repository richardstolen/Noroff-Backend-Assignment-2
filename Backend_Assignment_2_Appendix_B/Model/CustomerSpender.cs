using Backend_Assignment_2_Appendix_B.Model;
using System;
using System.Globalization;

namespace Backend_Assignment_2_Appendix_B.DataAccess
{
    public class CustomerSpender
    {
        public Customer Customer { get; set; }
        public Decimal Total { get; set; }

        public override string ToString()
        {
            return $"{Customer.FirstName} {Customer.LastName}: {Total.ToString("C", new CultureInfo("en-US"))}";
        }
    }
}