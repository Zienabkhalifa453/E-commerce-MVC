using System.ComponentModel.DataAnnotations;

namespace E_commerce.viewModels
{
    public class loginVm
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool RememberMe { get; set; }
   

    }
}
