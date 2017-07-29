using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.ViewModels;
using MovieStore.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    [Authorize(Roles = "Users")]
    public class CartController : Controller
    {
        // GET: /<controller>/

        public IActionResult ViewCart()
        {
            if (TempData["Movies"] is List<Movie>)
            {
                List<Rental> rentals = new List<Rental>();
                foreach (Movie m in (List<Movie>)TempData["Movies"])
                {
                    rentals.Add(new Rental()
                    {
                        Movie = m,
                        StartRentalDate = DateTime.Now,
                        EndRentalDate = DateTime.Now.AddDays(7)
                    });
                }
                CartModel model = new CartModel()
                {
                    Rentals = rentals
                };
                return View("Cart", model);
            }
            else
            {
                ViewBag.Error = "No Movies Found.";
                return View("Cart");
            }
        }

        public RedirectToActionResult GoToPayment(CartModel model)
        {
            PaymentModel Paymentmodel = new PaymentModel()
            {
                Rentals = model.Rentals,
                AmountPaid = model.Rentals.Sum(s => s.Cost * (s.EndRentalDate - s.StartRentalDate).Days)
                // User
            };
            return RedirectToAction("CreatePayment", Paymentmodel);
        }

        [HttpPost]
        public ActionResult CreatePayment(PaymentModel model)
        {
            if (ModelState.IsValid)
            {
                var db = new AppIdentityDbContext(null);
                Payment p = new Payment()
                {
                    DateofTransaction = DateTime.Now,
                    AmountPaid = model.AmountPaid,
                    User = model.User
                };
                db.Payments.Add(
                    p
                );
                foreach (Rental rental in p.Rentals)
                {
                    db.Rentals.Add(new Rental()
                    {
                        Movie = rental.Movie,
                        Payment = p,
                        StartRentalDate = rental.StartRentalDate,
                        EndRentalDate = rental.EndRentalDate
                    }
                    );
                }
                db.SaveChanges();
            }
            else
                TempData["Error"] = "Payment Failed";
            return View("Payment");
        }
    }

}