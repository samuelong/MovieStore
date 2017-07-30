using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System.Threading.Tasks;

namespace Users.Controllers
{
    public class RegisController : Controller
    {
        private UserManager<AppUser> userManager;
        public RegisController(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }
        public ViewResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model, string confirmPass)
        {
            if (ModelState.IsValid)
            {
                if (confirmPass != model.Password)
                {
                    ModelState.AddModelError("match", "Password does not match" + confirmPass + model.Password);
                    return View("Index", model);
                }
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Index", model);
        }
    }
}