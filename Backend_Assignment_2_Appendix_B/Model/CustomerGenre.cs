using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend_Assignment_2_Appendix_B.Model
{
    public class CustomerGenre
    {
        public Customer Customer { get; set; }
        public Dictionary<string, int> Genres { get; set; } = new Dictionary<string, int>();

        public string PrintGenres()
        {
            string result = string.Empty;

            var max = Genres.ElementAt(0);
            var max2 = Genres.ElementAt(1);

            if (max.Value == max2.Value)
            {
                result += max.Key + " and " + max2.Key;
            }
            else
            {
                result += max.Key;
            }

            return result;
        }
        public override string ToString()
        {
            return $"{Customer.FirstName} {Customer.LastName}: {PrintGenres()}\n";
        }
    }
}