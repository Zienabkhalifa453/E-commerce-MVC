using E_commerce.Models;
using E_commerce_MVC.Repository;
using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Controllers
{

    public class WishListController : Controller
    {
        private readonly IWishListRepository wishListRepository;
        private readonly IProductRepository productRepository;

        public WishListController(IWishListRepository wishListRepository, IProductRepository productRepository)
        {
            this.wishListRepository = wishListRepository;
            this.productRepository = productRepository;
        }
        //[Authorize]
        public IActionResult Index(string id)
        {
            List<WishList> wishLists = wishListRepository.GetAllbyCustomerId(id);
            WishListViewModel wishListViewModel = new WishListViewModel();
            foreach (WishList item in wishLists)
            {
                Product product = productRepository.Get(p => p.Id == item.Product_Id);
                wishListViewModel.ProductName.Add(product.Name);
                wishListViewModel.ProductId.Add(product.Id);
                wishListViewModel.ImgUrl.Add(product.Image_Url);
                wishListViewModel.Price.Add(product.Price);
                if (product.Quantity != 0)
                {
                    wishListViewModel.Stock.Add("Available");
                }
                else
                {
                    wishListViewModel.Stock.Add("Not Available");
                }
            }
            return View("Index", wishListViewModel);
        }
        public ActionResult Remove(int id)
        {
            WishList wishList = wishListRepository.Get(p => p.Product_Id == id);
            wishListRepository.delete(wishList);
            wishListRepository.save();
            return RedirectToAction("Index", new { id = wishList.Customer_Id });
        }


    }
}
