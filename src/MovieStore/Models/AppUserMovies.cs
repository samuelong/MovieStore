using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class AppUserMovies
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Key]
        public string UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
