using Microsoft.AspNetCore.Identity;

namespace Bar_rating.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Reviews = new HashSet<Reviews>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Reviews>? Reviews { get; set; }
    }
}
