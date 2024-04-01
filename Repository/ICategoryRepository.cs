using E_commerce.Models;
using E_commerce.Repository;

namespace E_commerce_MVC.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public string GetName(int id);
        public List<Category> GetAllCategories();
    }
}
