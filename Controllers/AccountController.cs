using E_commerce.Models;
using E_commerce.Repository;
using E_commerce.viewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        IRepository<ApplicationUser> _repository;
        IRepository<Product> _productRepository;
     
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IRepository<ApplicationUser>appRpo,IRepository<Product>Repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = appRpo;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }









        [HttpGet]
        public IActionResult register()
         {
            return View("register");

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> register(RegisterVm model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    UserName = model.userName,
                    PasswordHash = model.password,
                    Email = model.email,
                    Address=model.address,
                };
                IdentityResult identityResult = await _userManager.CreateAsync(applicationUser, model.password);

                if (identityResult.Succeeded)
                {
                    
                    await _signInManager.SignInAsync(applicationUser, false);

                 
                    return RedirectToAction("RegisteredCustomers");
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {

                        ModelState.AddModelError("", item.Description);
                    }

                }
            }
            return View("register", model);
        }




        // for trials only

        public IActionResult RegisteredCustomers()
        {
            List<ApplicationUser> customers =  _repository.GetAll().ToList();
           
            return View(customers);
        }


    }
}
