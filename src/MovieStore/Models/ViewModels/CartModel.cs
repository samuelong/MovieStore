using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models.ViewModels
{
    public class CartModel
    {
        private List<RentalModel> items = new List<RentalModel>();

        public CartModel(params RentalModel[] ri)
        {
            items.AddRange(ri);
        }

        public List<RentalModel> GetCart()
        { return items; }
    }
}
