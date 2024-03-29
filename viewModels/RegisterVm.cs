using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.viewModels
{
    public class RegisterVm
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Compare("password")]
        [DisplayName("password confirmation")]
        public string confirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DisplayName("Email confirmation")]
        [Compare("email")]
        public string emailConfirmation { get; set; }

        public string address { get; set; }


    }
}
