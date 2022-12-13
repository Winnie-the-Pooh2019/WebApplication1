using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models;

public record Category {
    [Key]
    public int id { get; init; }
    
    [Required]
    public string name { get; init; }
}