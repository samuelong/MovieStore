using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    public class ProfileController : Controller
    {
        // GET: /<controller>/
        public IActionResult Profile()
        {
            return View
                (
                new Customer("Test1", "IName", "MyEmail@Email.com", 999)
                );
        }
    }
}
