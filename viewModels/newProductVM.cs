using E_commerce.Models;

namespace E_commerce_MVC.viewModels
{
    public class newProductVM
    {

   
        public string Name { get; set; }
        public IFormFile Image_Url { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Category_Id { get; set; }
        public List<Category>? Category {  get; set; }

    }
}
