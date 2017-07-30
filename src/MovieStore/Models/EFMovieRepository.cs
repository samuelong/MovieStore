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
            if (movie.MovieID == 0)
            {
                context.Movies.Add(movie);
            }
            else
            {
                Movie dbEntry = context.Movies
                    .FirstOrDefault(m => m.MovieID == movie.MovieID);
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

        public Movie DeleteMovie(int movieID)
        {
            Movie dbEntry = context.Movies
                .FirstOrDefault(m => m.MovieID == movieID);
            if (dbEntry != null)
            {
                context.Movies.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}