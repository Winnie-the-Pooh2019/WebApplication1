using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models; 

public record Customer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; init; }
    
    [Required]
    public string firstName { get; init; }
    
    [Required]
    public string lastName { get; init; }
}