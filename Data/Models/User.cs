using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models;

public record User {
    [Key]
    public int id { get; init; }
    
    [Required]
    public string name { get; init; }
    
    [Required] 
    public string surname { get; init; }

    public ICollection<RoleUser> rolesUsers { get; init; }
};