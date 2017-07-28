using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    // HOMEPAGE FOR USERS
    [Authorize(Roles = "Users")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult GoToHomePage()
        {
            return View("HomePage");
        }

        public IActionResult ViewMovies()
        {
            return View("Movie");
        }

        public ActionResult GoToPayment()
        {
            return View("Payment");
        }


        // THESE ARE ADMIN HOMEPAGE STUFF. PUT IN YOUR OWN HOMEPAGE.
        public IActionResult Index() => View(GetData(nameof(Index)));
        [Authorize(Roles = "Users")]
        public IActionResult OtherAction() => View("Index", GetData(nameof(OtherAction)));

        private Dictionary<string, object> GetData(string actionName) => new Dictionary<string, object>
        {
            ["Action"] = actionName,
            ["User"] = HttpContext.User.Identity.Name,
            ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
            ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
            ["In Users Role"] = HttpContext.User.IsInRole("Users")
        };
    }
}
