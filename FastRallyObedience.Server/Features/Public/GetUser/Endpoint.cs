using FastEndpoints;

namespace GetUser;

internal sealed class GetUserEndpoint : Endpoint<EmptyRequest, Response, Mapper>
{
    private readonly GetUserData Data;

    public GetUserEndpoint(GetUserData data)
    {
        Data = data;
    }

    public override void Configure()
    {
        Get("api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var users = Data.GetAllUsers();
        //Response = Map.FromEntity(users);
        await SendAsync(Response);
    }
}