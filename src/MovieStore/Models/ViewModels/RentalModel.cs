using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace MovieStore.Models.ViewModels
{
    public class RentalModel : IEnumerable<RentalModel>
    {
        public Movie Movie { get; set; }
        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }
        public decimal Cost { get; set; }

        public RentalModel(Movie movie, DateTime start, DateTime end)
        {
            Movie = movie;
            StartRentalDate = start;
            EndRentalDate = end;
        }

        public IEnumerator<RentalModel> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


    }
}
