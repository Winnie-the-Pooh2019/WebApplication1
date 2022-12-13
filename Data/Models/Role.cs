namespace WebApplication1.Data.Models;

public record Role {
    public int id { get; init; }
    public string name { get; init; }

    public ICollection<RoleUser> users { get; init; }
}