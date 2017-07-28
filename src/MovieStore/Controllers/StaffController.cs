using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class StaffController : Controller
    {
        // GET: /<controller>/
        public IActionResult StaffProfile()
        {
            return View
                (
                new Staff("Brandon", "IName")
                );
        }
    }
}
