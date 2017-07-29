using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private AppIdentityDbContext context;

        public EFMovieRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Movie> Movies => context.Movies;

        public void SaveMovie(Movie movie)
        {
            if (movie.Title == "")
            {
                context.Movies.Add(movie);
            }
            else
            {
                Movie dbEntry = context.Movies
                    .FirstOrDefault(m => m.Title == movie.Title);
                if (dbEntry != null)
                {
                    dbEntry.Title = movie.Title;
                    dbEntry.DateReleased = movie.DateReleased;
                    dbEntry.Duration = movie.Duration;
                    dbEntry.Director = movie.Director;
                    dbEntry.Cast = movie.Cast;
                    dbEntry.Desc = movie.Desc;
                    dbEntry.Price = movie.Price;
                }
            }
            context.SaveChanges();
        }

        public Movie DeleteMovie(string title)
        {
            Movie dbEntry = context.Movies
                .FirstOrDefault(m => m.Title == title);
            if (dbEntry != null)
            {
                context.Movies.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}