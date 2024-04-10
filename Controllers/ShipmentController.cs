using E_commerce.Models;
using E_commerce.Repository;
using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce_MVC.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IRepository<Shipment> repository;
        private readonly UserManager<ApplicationUser> userManager;

        public ShipmentController(IRepository<Shipment> repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }


        //for admin ya reem
        // [Authorize(Roles = "admin")]
        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            var shipments = repository.GetAll();
            var users = userManager.Users.ToList();
            ViewData["Users"] = users;

            var paginatedShipments = shipments.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (shipments.Count + pageSize - 1) / pageSize;

            return View(paginatedShipments);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> AddShipment()
        {
            var currentUser = await userManager.GetUserAsync(User);
            string email = currentUser.Email;
            ViewData["Email"] = email;
            string username = User.Identity.Name;
            ViewData["Username"] = username;
            return View("AddShipment");
        }


        [HttpPost]
        public IActionResult AddShipment(ShipmentViewModel shipmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Shipment shipment = new()
                {
                    Date = shipmentViewModel.Date,
                    Address = shipmentViewModel.Address,
                    City = shipmentViewModel.City,
                    State = shipmentViewModel.State,
                    Country = shipmentViewModel.Country,
                    Zip_Code = shipmentViewModel.Zip_Code,
                    Customer_Id = User.FindFirstValue(ClaimTypes.NameIdentifier)

                };
                repository.insert(shipment);
                repository.save();
                //return Content("Done");
                return RedirectToAction("AddPayment", "Payment");
            }
            return View("AddShipment");
        }
    }
}
