namespace E_commerce_MVC.viewModels
{
    public class WishListViewModel
    {
        public WishListViewModel()
        {
            ProductName = new List<string>();
            ProductId = new List<int>();
            ImgUrl = new List<string>();
            Price = new List<double>();
            Stock = new List<string>();
        }
        public List<string> ProductName { get; set; }
        public List<int> ProductId { get; set; }
        public List<string> ImgUrl { get; set; }
        public List<double> Price { get; set; }
        public List<string> Stock { get; set; }
    }
}
