﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace MovieStore.Models.ViewModels
{
    public class CartModel : IEnumerable<CartModel>
    {
        public List<Rental> Rentals { get; set; }

        public IEnumerator<CartModel> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
