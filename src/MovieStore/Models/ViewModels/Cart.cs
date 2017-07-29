using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models.ViewModels
{
    public class Cart
    {
        private List<Rental> items = new List<Rental>();

        public Cart(params Rental[] ri)
        {
            items.AddRange(ri);
        }

        public List<Rental> GetCart()
        { return items; }
    }
}
