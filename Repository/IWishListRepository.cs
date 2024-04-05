using E_commerce.Models;
using E_commerce.Repository;

namespace E_commerce_MVC.Repository
{
    public interface IWishListRepository : IRepository<WishList>
    {
        public List<WishList> GetAllbyCustomerId(string id);
    }
}