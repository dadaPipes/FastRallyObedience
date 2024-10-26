using FastRallyObedience.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace FastRallyObedience.Server.Data;

public static class RoleSeeder
{
    private static readonly string[] roles = { "Admin", "Judge", "DogHandler" };

    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Check if roles already exist
        if (await context.Roles.AnyAsync())
        {
            return; // Roles already seeded
        }

        // Seed the roles
        foreach (var roleName in roles)
        {
            var role = new AppUserRole
            {
                Name = roleName
            };

            await context.Roles.AddAsync(role);
        }

        await context.SaveChangesAsync();
    }
}
