﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace MovieStore.Models
{
    public class Payment : IEnumerable<Payment>
    {
        public Payment() { }
        
        public Payment(AppUser user, DateTime dateofTransaction, decimal amountPaid)
        {
            User = user;
            DateofTransaction = dateofTransaction;
            AmountPaid = amountPaid;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        //[Required]
        [ForeignKey("Id")]
        public virtual AppUser User { get; set; }

        //[Required]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DateofTransaction { get; set; }

        //[Required]
        public decimal AmountPaid { get; set; }

        public IEnumerator<Payment> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
