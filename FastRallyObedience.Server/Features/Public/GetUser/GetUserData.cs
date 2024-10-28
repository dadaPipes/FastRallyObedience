using FastRallyObedience.Server.Data;
using FastRallyObedience.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace GetUser
{
    internal sealed class GetUserData
    {
        private readonly AppDbContext _dbContext;

        public GetUserData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<AppUser>> GetAllUsers()
        {
            return _dbContext.Users
            .Include(u => u.Roles)
            .ToListAsync();
        }
    }
}
