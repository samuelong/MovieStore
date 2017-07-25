using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace MovieStore.Models
{
    public class Cart : IEnumerable<Cart>
    {
        private List<RentalInfo> items = new List<RentalInfo>();

        public Cart(params RentalInfo[] ri)
        {
            items.AddRange(ri);
        }

        public List<RentalInfo> GetCart()
        { return items; }

        public IEnumerator<Cart> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
