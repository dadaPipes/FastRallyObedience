using FastEndpoints;
using FastRallyObedience.Server.Data;
using FastRallyObedience.Server.Domain;

namespace DockerTryOut
{
    internal sealed class Endpoint : Endpoint<Request>
    {
        private readonly AppDbContext _dbContext;

        public Endpoint(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Post("route");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            // Create a new user instance and set its properties
            var user = new AppUser
            {
                Name = "Brian"  // Assuming 'Name' is a property of AppUser
            };

            // Add the user to the DbContext and save the changes
            await _dbContext.Users.AddAsync(user, c);
            await _dbContext.SaveChangesAsync(c);

            // Send a response back (if needed)
            await SendOkAsync(c);
        }
    }
}