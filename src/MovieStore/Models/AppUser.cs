using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class AppUser: IdentityUser
    {
        //C.30 application-specific user data
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<AppUserMovies> Movies { get; set; }
    }
}
