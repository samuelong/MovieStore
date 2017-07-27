using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MovieStore.Models
{
    [Authorize]
    public class RentalInfo
    {
        public Movie Movie { get; set; }
        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }

        public RentalInfo(Movie movie, DateTime start, DateTime end)
        {
            Movie = movie;
            StartRentalDate = start;
            EndRentalDate = end;
        }
    }
}
