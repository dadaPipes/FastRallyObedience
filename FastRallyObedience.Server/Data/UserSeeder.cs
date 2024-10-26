using FastRallyObedience.Server.Domain;

namespace FastRallyObedience.Server.Data;

public static class UserSeeder
{
    private static readonly IEnumerable<SeedUser> seedUsers =
    [
        new SeedUser
        {
            Email    = "admin@admin.com",
            RoleList = ["Admin", "Judge"],
            Name     = "admin@admin.com"
        },
        new SeedUser
        {
            Email    = "doghandler@doghandler.com",
            RoleList = ["DogHandler"],
            Name     = "doghandler@doghandler.com"
        },
    ];

    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (context.Users.Any())
        {
            return; // Users already seeded
        }

        // Create roles if they do not exist
        var roles = new[] { "Admin", "Judge", "DogHandler" };

        foreach (var role in roles)
        {
            if (!context.Roles.Any(r => r.Name == role))
            {
                context.Roles.Add(new AppUserRole { Name = role });
            }
        }

        // Add users to the context
        foreach (var user in seedUsers)
        {
            // Hash the password using BCrypt
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Passw0rd!");

            context.Users.Add(user);

            // Assign roles to the user
            foreach (var roleName in user.RoleList)
            {
                var role = context.Roles.FirstOrDefault(r => r.Name == roleName);
                if (role != null)
                {
                    user.Roles.Add(role);
                }
            }
        }

        await context.SaveChangesAsync();
    }

    private sealed class SeedUser : AppUser
    {
        public string[] RoleList { get; set; } = [];
    }
}
