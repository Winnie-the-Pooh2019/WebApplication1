using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models; 

public record Customer {
    [Required]
    [Key]
    public int id { get; init; }
    
    [Required]
    public string firstName { get; init; }
    
    [Required]
    public string lastName { get; init; }
}