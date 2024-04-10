using E_commerce.Models;
using E_commerce.Repository;
using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce_MVC.Controllers
{
    public class PaymentController : Controller
    {

        private readonly IRepository<Payment> repository;
        private readonly UserManager<ApplicationUser> userManager;


        public PaymentController(IRepository<Payment> repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        //for admin ya reem
        // [Authorize(Roles = "admin")]
        public IActionResult Index(int page = 1, int pageSize = 2)
        {

            var payments = repository.GetAll();
            var users = userManager.Users.ToList();
            ViewData["Users"] = users;
            var paginatedShipments = payments.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (payments.Count + pageSize - 1) / pageSize;

            return View(paginatedShipments);
        }
        [HttpGet]
        // [Authorize]
        public IActionResult AddPayment()
        {

            return View("AddPayment");
        }

        [HttpPost]
        public IActionResult AddPayment(PaymentViewModel paymentVm)
        {
            if (ModelState.IsValid == true)
            {

                //must be login
                var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var payment = new Payment
                {
                    Date = DateTime.Now,
                    Method = paymentVm.Method,
                    Amount = paymentVm.Amount,
                    Customer_Id = customerId

                };
                repository.insert(payment);
                repository.save();
                return RedirectToAction("End");
            }

            return View("AddPayment", paymentVm);
        }

        public IActionResult End()
        {
            return View();
        }
    }
}
