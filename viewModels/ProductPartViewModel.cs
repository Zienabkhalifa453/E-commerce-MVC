namespace E_commerce_MVC.viewModels
{
    public class ProductPartViewModel
    {
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<int> ProductsId { get; set; }
        public List<string> ProductNames { get; set; }
        public List<String> Image_Url { get; set; }
        public List<double> Price { get; set; }
       
    }
}
