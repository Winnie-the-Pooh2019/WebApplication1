using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models; 

public record Customer {
    [Required]
    [Key]
    public int id { get; init; }
    
    [Required]
    public string firstName { get; init; }
    
    [Required]
    public string lastName { get; init; }
}