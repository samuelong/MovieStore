using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class FakeMovieRepository : IMovieRepository
    {
        public IEnumerable<Movie> Movies => new List<Movie>
        {
            new Movie("Superman", new DateTime(2017, 1, 1), 60, "Brandon", new List<string> { "Brandon", "Samuel", "Jourdan" }, "", 100)
        };
    }
}
