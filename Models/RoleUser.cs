using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(rolesid), nameof(usersid))]
public record RoleUser {
    [ForeignKey(nameof(role))]
    public int rolesid { get; init; }
    
    [ForeignKey(nameof(user))]
    public int usersid { get; init; }

    public Role role { get; set; }
    public User user { get; set; }
}