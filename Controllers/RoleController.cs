using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
       // [Authorize(Roles = "Admin")]
        public IActionResult AddRole()
        {
            // Check if the current user is in the "Admin" role
          
                return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(RoleViewModel roleVm)
        {
            if (ModelState.IsValid)
            {
                IdentityRole roleModel = new IdentityRole
                {
                    Name = roleVm.RoleName
                };

                var result = await roleManager.CreateAsync(roleModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View("AddRole", roleVm);
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
