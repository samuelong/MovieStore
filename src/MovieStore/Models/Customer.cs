using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Customer
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }
        private List<Movie> movie = new List<Movie>();

        public Customer(string memberid, string name, string email, int phoneNo)
        {
            MemberID = memberid;
            Name = name;
            Email = email;
            PhoneNo = phoneNo;
            GetMovies(ref movie);
        }

        public void GetMovies(ref List<Movie> movie)
        {
            // Get movies from Database
        }
    }
}
