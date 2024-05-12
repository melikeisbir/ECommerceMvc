using Microsoft.AspNetCore.Identity;

namespace ECommerceMvc.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        
    }
}
