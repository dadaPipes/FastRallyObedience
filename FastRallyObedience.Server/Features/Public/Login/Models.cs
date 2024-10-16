using FastEndpoints;
using FluentValidation;

namespace FastRallyObedience.Server.Features.Public.Login
{
    public sealed class Request
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        internal sealed class Validator : Validator<Request>
        {
            public Validator()
            {
                RuleFor(r => r.Username)
                    .NotEmpty().WithMessage("Username is required.");

                RuleFor(r => r.Password)
                    .NotEmpty().WithMessage("Password is required.");
            }
        }
    }

    public sealed class Response
    {
        public string Message => "This endpoint hasn't been implemented yet!";
    }
}
