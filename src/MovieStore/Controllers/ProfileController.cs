using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<AppUser> userManager;
        AppIdentityDbContext db;
        public ProfileController(AppIdentityDbContext context, UserManager<AppUser> userMgr)
        {
            db = context;
            userManager = userMgr;
        }


        // GET: /<controller>/
        /*public async Task<IActionResult> Profile(IHttpContextAccessor httpContextAccessor)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //AppUser user = userManager.FindByIdAsync(userId);
        }
        */
    }
}
