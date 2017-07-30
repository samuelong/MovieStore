using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalID { get; set; }

        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }
        public decimal Cost { get; set; }

        public int PaymentId { get; set; }
        public string MovieTitle { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
