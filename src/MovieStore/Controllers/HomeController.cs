using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult GoToHomePage()
        {
            return View("HomePage");
        }

        public IActionResult ViewCart()
        {
            return View("Cart");
        }

        public IActionResult ViewProfile()
        {
            return View("Profile");
        }

        public IActionResult ViewMovies()
        {
            return View("Movie");
        }

        [HttpPost]
        public ActionResult GoToPayment()
        {
            return View("Payment");
        }

        public ViewResult Index() => View(new Dictionary<string, object> { ["Placeholder"] = "Placeholder" });
    }
}
