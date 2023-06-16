using Microsoft.AspNetCore.Identity;

namespace HouseforRentProject.Models.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
    }
}
