using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using MovieStore.Models.ViewModels;

namespace MovieStore.Models.ViewModels
{
    public class CartModel
    {
        public List<RentalModel> Rentals { get; set; }
    }
}
