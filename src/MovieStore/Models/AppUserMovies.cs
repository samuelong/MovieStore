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
        [Key]
        [Column(Order = 0)]
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
