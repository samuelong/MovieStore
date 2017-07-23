using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public List<string> Cast { get; set; }
        public string Desc { get; set; }

        public Movie(string title, DateTime dateReleased, int duration, string director, List<string> cast, string desc)
        {
            Title = title;
            DateReleased = dateReleased;
            Duration = duration;
            Director = director;
            Cast = cast;
            Desc = desc;
        }
    }
}
