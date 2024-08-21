using Microsoft.AspNetCore.Identity;

namespace Prismproject_A.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

       // public string Address { get; set; } = "";

        public DateTime CreatedAt { get; set; }
        public string District { get; set; } = "";

       // public string IDRCIDNumber { get; set; } = "";
    }
}
