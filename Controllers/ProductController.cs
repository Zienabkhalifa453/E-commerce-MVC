using E_commerce.Models;
using E_commerce_MVC.Repository;
using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IProductRepository ProductRepository, ICategoryRepository CategoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.ProductRepository = ProductRepository;
            this.CategoryRepository = CategoryRepository;
            this.webHostEnvironment = webHostEnvironment;
        }


        public IActionResult show()
        {
          List<Product> newproduct = ProductRepository.GetAll().ToList();
         
            return View(newproduct);
        }

      
        public IActionResult addNewProduct()
        {
            newProductVM newProductVM = new newProductVM();
            newProductVM.Category = CategoryRepository.GetAll().ToList();
            return View(newProductVM);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult addNewProduct(newProductVM newProduct)
        {

            if (ModelState.IsValid)
            {
                string UploadPath = Path.Combine(webHostEnvironment.WebRootPath, "img/gallery");
                string imageName = Guid.NewGuid().ToString() + "-" + newProduct.Image_Url.FileName;
                string filePath = Path.Combine(UploadPath, imageName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    newProduct.Image_Url.CopyTo(fileStream);
                }

                Product product = new Product();
                product.Name = newProduct.Name;
                product.Image_Url = imageName;
                product.Price = newProduct.Price;
                product.Description = newProduct.Description;
                product.Category_Id = newProduct.Category_Id;
                product.Quantity=newProduct.Quantity;

                ProductRepository.insert(product);
                ProductRepository.save();


                return RedirectToAction("show");
            }

            newProduct.Category = CategoryRepository.GetAll().ToList();
            return View(newProduct);
        }




    

        public IActionResult Index()
        {
            return View();
        } 

        //dina controllers

        public IActionResult GetAllProducts()
        {
            List<Product> products = (List<Product>)ProductRepository.GetAll();
            return View("GetAllProducts",products);
        }

        public IActionResult GetProductsByCategoryId(int CategoryId)
        {
            List<string> productNames = ProductRepository.GetProductNamesByCatId(CategoryId);
            List<string> productImages = ProductRepository.GetProductImagesByCatId(CategoryId);
            List<double> productPrices = ProductRepository.GetProductPricesByCatId(CategoryId);
            List<int> productIds = ProductRepository.GetProductIDsByCatId(CategoryId);

            string CategoryName = CategoryRepository.GetName(CategoryId);

            ProductPartViewModel productPartViewModel = new ProductPartViewModel()
            {
                CategoryId = CategoryId,
                CategoryName = CategoryName,
                Price = productPrices,
                ProductNames = productNames,
                ProductsId = productIds
            };

            return View("GetProductsByCategoryId" , productPartViewModel);
        }

        public IActionResult AddToCart(int ProductId)
        {
            Product product = ProductRepository.Get(p => p.Id == ProductId);
            return View("ShoppingCart",product);
        }

        
        public IActionResult AddToWishList(int ProductId)
        {
            Product product = ProductRepository.Get(p => p.Id == ProductId);
            return View("wishingList",product);
        }

        //Get latest product in each category
        //public IActionResult GetLatestProduct()
        //{
        //    List<Product> latestProductsInCategories = (List<Product>)ProductRepository.GetLatestProduct();
        //    ViewBag.Products = latestProductsInCategories;
        //    return View("_GetLatestProduct");

        //}

    }
}
