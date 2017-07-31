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
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    [Authorize(Roles = "Users")]
    public class CartController : Controller
    {
        AppIdentityDbContext db;
        UserManager<AppUser> userManager;
        public CartController(AppIdentityDbContext context, UserManager<AppUser> userMngr)
        {
            db = context;
            userManager = userMngr;
        }
        // GET: /<controller>/

        public IActionResult ViewCart()
        {
            TempData["Movies"] = db.Movies.ToList();
            if (TempData["Movies"] is List<Movie>)
            {
                List<RentalModel> rentals = new List<RentalModel>();
                foreach (Movie m in (List<Movie>)TempData["Movies"])
                {
                    rentals.Add(new RentalModel()
                    {
                        MovieTitle = m.Title,
                        StartRentalDate = DateTime.Now,
                        EndRentalDate = DateTime.Now.AddDays(7),
                        Cost = m.Price*7,
                        MovieID = m.MovieID,
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
                return View("Cart");
            }
        }

        public ActionResult GoToPayment(CartModel model)
        {
            if (ModelState.IsValid)
            {
                PaymentModel Paymentmodel = new PaymentModel()
                {
                    Rentals = model.Rentals,
                    AmountPaid = model.Rentals.Sum(s => s.Cost * (s.EndRentalDate - s.StartRentalDate).Days),
                };
                return View("Payment", Paymentmodel);
            }
            ModelState.AddModelError(string.Empty, "Movies provided incorrect");
            return RedirectToAction("ViewCart", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePayment(PaymentModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                Payment p = new Payment()
                {
                    DateofTransaction = DateTime.Now,
                    AmountPaid = model.AmountPaid,
                    User = await userManager.FindByNameAsync(User.Identity.Name)
                };
                List<Rental> rentals = new List<Rental>();
                for(int i = 0; i < model.Rentals.Count; i++ )
                {
                    rentals.Add(
                        new Rental()
                        {
                            MovieId = model.Rentals[i].MovieID,
                            Payment = p,
                            Cost = model.Rentals[i].Cost,
                            StartRentalDate = model.Rentals[i].StartRentalDate,
                            EndRentalDate = model.Rentals[i].EndRentalDate
                        }
                        );
                }
                foreach (Rental rental in rentals)
                {
                    db.Rentals.Add(new Rental()
                    {
                        MovieId = rental.MovieId,
                        Payment = p,
                        StartRentalDate = rental.StartRentalDate,
                        EndRentalDate = rental.EndRentalDate,
                        Cost = rental.Cost
                    }
                    );
                }
                db.SaveChanges();
            }
            else
            {
                TempData["Error"] = "Payment Failed";
                return View("Payment", model);
            }
            return RedirectToAction("ViewCart");
        }
    }

}