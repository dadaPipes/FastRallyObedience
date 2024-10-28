using FastEndpoints;
using FastRallyObedience.Server.Domain;

namespace GetUser;

internal sealed class Mapper : ResponseMapper<Response, AppUser>
{
    public override Response FromEntity(AppUser au) => new()
    {
        Id    = au.Id,
        Name  = au.Name,
        Email = au.Email,
        Roles = au.Roles.Select(ar => ar.Name).ToList()
    };
}