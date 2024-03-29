using E_commerce.Repository;

using Microsoft.AspNetCore.Identity;


namespace E_commerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }


     
    }
}
