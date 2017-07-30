using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace MovieStore.Models
{
    public class Payment
    {
        public Payment() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        public DateTime DateofTransaction { get; set; }

        public decimal AmountPaid { get; set; }


        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
