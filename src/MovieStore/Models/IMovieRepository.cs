using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
        void SaveMovie(Movie movie);
        Movie DeleteMovie(string title);
    }
}
