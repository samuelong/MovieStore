using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Review
    {
        public string Name { get; set; }
        public string Comment { get; set; }

        public Review(string n, string c)
        {
            Name = n;
            Comment = c;
        }
    }
}
