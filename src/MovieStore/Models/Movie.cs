using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    [Authorize]
    public class Movie : IEnumerable<Movie>
    {
        [Key]
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }

        public Movie() { }

        public Movie(string title, DateTime dateReleased, int duration, string director, string cast, string desc, decimal price)
        {
            Title = title;
            DateReleased = dateReleased;
            Duration = duration;
            Director = director;
            Cast = cast;
            Desc = desc;
            Price = price;
        }

        public IEnumerator<Movie> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
