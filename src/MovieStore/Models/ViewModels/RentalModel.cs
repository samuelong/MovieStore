using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models.ViewModels
{
    public class RentalModel
    {
        public int RentalID { get; set; }

        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }
        public decimal Cost { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
    }
}
