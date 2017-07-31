using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MovieStore.Models.ViewModels
{
    public class PaymentModel
    {
        public PaymentModel() { }

        public decimal AmountPaid { get; set; }

        public List<RentalModel> Rentals { get; set; }
    }
}
