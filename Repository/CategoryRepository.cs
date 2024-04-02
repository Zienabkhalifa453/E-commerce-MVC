using E_commerce.Models;
using E_commerce.Repository;

namespace E_commerce_MVC.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }


        public string GetName(int id)
        {
            return context.Categories.Where(c => c.Id == id).First().Name;
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
    }
}
