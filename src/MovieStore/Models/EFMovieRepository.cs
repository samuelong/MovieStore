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
    }
}