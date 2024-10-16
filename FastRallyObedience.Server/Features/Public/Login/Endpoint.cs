using FastEndpoints;
using FastRallyObedience.Server.Features.Public.Login;

namespace Login
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken ct)
        {
            await SendAsync(new Response());
        }
    }
}