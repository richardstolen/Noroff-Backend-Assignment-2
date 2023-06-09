﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment_2_Appendix_B.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {CustomerId}, Name: {FirstName} {LastName}, " +
                $"Address: {Country} {PostalCode}, Phone: {Phone}, Email: {Email}";
        }
    }
}
