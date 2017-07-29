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

        //[Required]
        [ForeignKey("Id")]
        public virtual AppUser User { get; set; }

        //[Required]
        public DateTime DateofTransaction { get; set; }

        //[Required]
        public decimal AmountPaid { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
