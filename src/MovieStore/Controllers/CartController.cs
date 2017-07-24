using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    public class CartController : Controller
    {
        // GET: /<controller>/

        public IActionResult ViewCart()
        {
            return View("Cart", new List<Movie>()
            {
                new Movie("test1", Convert.ToDateTime("2017-07-24"), 140, "Test1Director",
                new List<string>()
                {
                    "Actor1",
                    "Actor2"
                },
                "A test show"
                ),
                new Movie("test2", Convert.ToDateTime("2016-07-24"), 140, "Test2Director",
                new List<string>()
                {
                    "Actor1",
                    "Actor2"
                },
                "A test2 show"
                )
            }
                );
        }
    }
}
