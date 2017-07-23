using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Cart
    {
        public List<RentalInfo> items = new List<RentalInfo>();
        public Cart(params RentalInfo[] ri)
        {
            items.AddRange(ri);
        }
    }
}
