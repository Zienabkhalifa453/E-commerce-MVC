using E_commerce.Models;
using E_commerce_MVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Controllers
{

    public class CategoryController : Controller
    {

        private readonly ICategoryRepository CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            this.CategoryRepository = CategoryRepository;
        }


        public IActionResult Index()
        {
            return View();
        }



        public IActionResult GetAllCategory()
        {
            List<Category> categories = (List<Category>)CategoryRepository.GetAllCategories();
            return View("GetAllCategory",categories);
        }

    }
}
