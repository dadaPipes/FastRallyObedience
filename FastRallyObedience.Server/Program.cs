using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

namespace FastRallyObedience.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHttpClient();

        builder.Services
           .AddAuthenticationCookie(validFor: TimeSpan.FromMinutes(30))
           .AddAuthorization()
           .AddFastEndpoints()
           .SwaggerDocument();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {

        }

        app.UseHttpsRedirection();

        app.UseDefaultExceptionHandler()
           .UseAuthentication()
           .UseAuthorization()
           .UseFastEndpoints()
           .UseSwaggerGen();

        app.Run();
    }
}
