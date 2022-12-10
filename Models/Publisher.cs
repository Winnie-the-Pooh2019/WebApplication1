using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("publisher")]
public record Publisher {
    [Key]
    public int id { get; init; }
    
    [Required]
    public string name { get; init; }
};