using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models; 

[Table("clients")]
public record Client {
    [Required]
    [Key]
    public int id { get; init; }
    
    [Column("first_name")]
    [Required]
    public string firstName { get; init; }
    
    [Column("last_name")]
    [Required]
    public string lastName { get; init; }
}