using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models;

public record Publisher {
    [Key]
    public int id { get; init; }
    
    [Required]
    public string name { get; init; }
};