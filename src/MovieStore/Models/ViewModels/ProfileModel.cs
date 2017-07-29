using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStore.Models;

namespace MovieStore.Models.ViewModels
{
    public class ProfileModel
    {
        public string Name { get; set; }
        public List<Rental> Rentals { get; set; }

    }
}
