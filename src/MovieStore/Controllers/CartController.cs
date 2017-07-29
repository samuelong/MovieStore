using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.ViewModels;
using MovieStore.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    [Authorize(Roles = "Users")]
    public class CartController : Controller
    {
        // GET: /<controller>/

        public IActionResult ViewCart()
        {
            // Returning View with Cart
            return View
            ("Cart", 
                new CartModel
                (
                    new Models.ViewModels.RentalModel
                    (
                        new Movie("test1", Convert.ToDateTime("2017-07-24"), 140, "Test1Director",
                        "Actor 1, Actor 2",
                        "A test show",
                        20.5m
                        ),
                        Convert.ToDateTime("2017-08-29"),
                        Convert.ToDateTime("2017-09-20")
                    ),
                    new Models.ViewModels.RentalModel
                    (
                        new Movie("test2", Convert.ToDateTime("2016-07-24"), 140, "Test2Director",
                        "Actor 1, Actor 2",
                        "A test2 show",
                        32.4m
                        ),
                        Convert.ToDateTime("2017-08-29"),
                        Convert.ToDateTime("2017-09-20")
                    )
                )
            );
        }
    }
}