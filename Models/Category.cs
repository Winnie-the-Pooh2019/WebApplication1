using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("categories")]
public record Category {
    [Key]
    public int id { get; init; }
    
    [Required]
    public string name { get; init; }
}