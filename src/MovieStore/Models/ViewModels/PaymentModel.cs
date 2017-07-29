using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MovieStore.Models.ViewModels
{
    public class PaymentModel : IEnumerable<PaymentModel>
    {
        public PaymentModel() { }
        public AppUser User { get; set; }

        public decimal AmountPaid { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public IEnumerator<PaymentModel> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
