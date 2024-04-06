using E_commerce.Models;
using E_commerce_MVC.Repository;
using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Controllers
{

    //[Route("Home")]
    public class CategoryController : Controller
    {

        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoryController(IProductRepository ProductRepository, ICategoryRepository CategoryRepository,IWebHostEnvironment webHostEnvironment)
        {
            this.ProductRepository = ProductRepository;
            this.CategoryRepository = CategoryRepository;
            this.webHostEnvironment = webHostEnvironment;
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


        public IActionResult addNewCategory()
        {

            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult addNewCategory(NewcategoryVM newcategory)
        {
            if (ModelState.IsValid)
            {
                string UploadPath = Path.Combine(webHostEnvironment.WebRootPath, "img/gallery");
                string imageName = Guid.NewGuid().ToString() + "-" + newcategory.imageURL.FileName;
                string filePath = Path.Combine(UploadPath, imageName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    newcategory.imageURL.CopyTo(fileStream);
                }

                Category category = new Category();
                category.Name = newcategory.Name;
                category.imageURL = imageName;

                CategoryRepository.insert(category);
                CategoryRepository.save();

        
                return RedirectToAction("GetAllCategory");
            }

       
            return View(newcategory);
        }
    }
}
