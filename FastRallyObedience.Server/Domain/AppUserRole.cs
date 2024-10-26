namespace FastRallyObedience.Server.Domain;

public class AppUserRole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<AppUser> Users { get; set; } = [];
}