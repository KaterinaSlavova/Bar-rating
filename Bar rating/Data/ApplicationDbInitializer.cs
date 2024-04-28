using Bar_rating.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bar_rating.Data
{
    public class ApplicationDbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                SeedUsers(userManager, roleManager);
            }
        }
        public static void SeedUsers(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                roleManager.CreateAsync(new IdentityRole()
                {
                    Name = "Administrator"
                }).Wait();

                roleManager.CreateAsync(new IdentityRole()
                {
                    Name = "User"
                }).Wait();

                if (userManager.FindByNameAsync("Administrator").Result == null)
                {
                    var adminUser = new AppUser()
                    {
                        UserName = "Admin",
                        Email = "admin@mail.bg",
                        FirstName = "Admicho",
                        LastName = "Adminchev"
                    };
                    IdentityResult adminCreated = userManager.CreateAsync(adminUser, "Admin@123").Result;
                    if (adminCreated.Succeeded)
                    {
                        userManager.AddToRoleAsync(adminUser, "Administrator").Wait();
                    }
                }
                if (userManager.FindByNameAsync("User").Result == null)
                {
                    var adminUser = new AppUser()
                    {
                        UserName = "User",
                        Email = "user@mail.bg",
                        FirstName = "Usercho",
                        LastName = "Userchev"
                    };
                    IdentityResult adminCreated = userManager.CreateAsync(adminUser, "User@123").Result;
                    if (adminCreated.Succeeded)
                    {
                        userManager.AddToRoleAsync(adminUser, "User").Wait();
                    }
                }
            }
        }
    }
}
