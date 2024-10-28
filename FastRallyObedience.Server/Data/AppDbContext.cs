using FastRallyObedience.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace FastRallyObedience.Server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<AppUserRole> Roles { get; set; }
}