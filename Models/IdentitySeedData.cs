using Microsoft.AspNetCore.Identity;

namespace mvc_project_dotnet.Models
{
    public class IdentitySeedData
    {

        public static void CreateAdminAccount(IServiceProvider serviceProvider,
                IConfiguration configuration)
        {
            CreateAdminAccountAsync(serviceProvider, configuration).Wait();
        }

        public static async Task CreateAdminAccountAsync(IServiceProvider
                serviceProvider, IConfiguration configuration)
        {

            //The UserManager<T> and RoleManager<T> services are scoped, which means I need to create a new
            //scope before requesting the services since the seeding will be done when the application starts.
            serviceProvider = serviceProvider.CreateScope().ServiceProvider;

            UserManager<IdentityUser> userManager =
                serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //The values for the seed data are read from the application’s configuration with fallback values,
            //making it easy to configure the seeded account without needing a code change
            string username = configuration["Data:AdminUser:Name"] ?? "admin";
            string email = configuration["Data:AdminUser:Email"] ?? "admin@example.com";
            string password = configuration["Data:AdminUser:Password"] ?? "secret";
            string role = configuration["Data:AdminUser:Role"] ?? "Admins";

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                IdentityUser user = new IdentityUser
                {
                    UserName = username,
                    Email = email
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}

