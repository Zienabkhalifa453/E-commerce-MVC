using E_commerce.Models;
using E_commerce.Repository;

namespace E_commerce_MVC.Repository
{
    public class WishListRepository : Repository<WishList>, IWishListRepository
    {
        public WishListRepository(Context context) : base(context)
        {

        }
        public List<WishList> GetAllbyCustomerId(string id)
        {
            List<WishList> wishLists = context.WishLists.
                Where(item => item.Customer_Id == id && item.IsDeleted == false).ToList();
            return wishLists;
        }

    }
}
