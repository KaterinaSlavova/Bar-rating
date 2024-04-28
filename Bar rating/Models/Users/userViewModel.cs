using System.ComponentModel.DataAnnotations;

namespace Bar_rating.Models.Users
{
    public class userViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }
}
