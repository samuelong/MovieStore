﻿using System;
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
        public int RentalID { get; set; }

        //[ForeignKey("Id")]
        //public virtual Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser IdentityUser { get; set; }
        public int MovieID { get; set; }
        public DateTime StartRentalDate { get; set; }
        public DateTime EndRentalDate { get; set; }
        public decimal Cost { get; set; }
    }
}
