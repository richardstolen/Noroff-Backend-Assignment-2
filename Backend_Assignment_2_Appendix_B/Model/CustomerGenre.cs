using System.Collections.Generic;

namespace Backend_Assignment_2_Appendix_B.Model
{
    public class CustomerGenre
    {
        public Customer Customer { get; set; }

        public List<string> Genres { get; set; }

        public override string ToString()
        {
            return $"{Customer.FirstName} {Genres}";
        }
    }
}