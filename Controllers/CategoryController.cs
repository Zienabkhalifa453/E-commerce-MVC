using E_commerce.Models;
using E_commerce_MVC.Repository;
using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Controllers
{

    public class CategoryController : Controller
    {

        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;

        public CategoryController(IProductRepository ProductRepository, ICategoryRepository CategoryRepository)
        {
            this.ProductRepository = ProductRepository;
            this.CategoryRepository = CategoryRepository;
        }


        public IActionResult Index()
        {
            return View();
        }



        public IActionResult GetAllCategory()
        {
            List<Category> categories = (List<Category>)CategoryRepository.GetAllCategories();
            List<Product> latestProductsInCategories = (List<Product>)ProductRepository.GetLatestProduct();
            ListOfProductAndListOfCategory ListOfProductAndListOfCategory = new ListOfProductAndListOfCategory();
            ListOfProductAndListOfCategory.categories = categories;
            ListOfProductAndListOfCategory.products = latestProductsInCategories;
            return View("GetAllCategory", ListOfProductAndListOfCategory);
        }

    }
}
