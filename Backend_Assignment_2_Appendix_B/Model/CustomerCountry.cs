using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment_2_Appendix_B.Model
{
    public class CustomerCountry
    {
        public string Country { get; set; }
        public int NumberOfCustomers { get; set; }

        public override string ToString()
        {
            return $"{Country}: {NumberOfCustomers}";
        }
    }
}
