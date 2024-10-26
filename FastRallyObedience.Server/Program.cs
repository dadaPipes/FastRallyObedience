using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using FastRallyObedience.Server.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services
    .AddAuthenticationCookie(validFor: TimeSpan.FromMinutes(30))
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        options =>
        {
            
        });

    options.EnableDetailedErrors(true);
    options.EnableSensitiveDataLogging(true);
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("devPolicy",
            builder => builder.WithOrigins("https://localhost:5001")
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials());
    });
}

var app = builder.Build();

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseCors("devPolicy");
}

app.UseDefaultExceptionHandler()
   .UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();

app.Run();