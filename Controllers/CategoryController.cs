using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult GetAllCategory()
        {
            return View();
        }

    }
}
