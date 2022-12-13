using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record PriceChange {
    [Key]
    public int id { get; init; }
    
    [Column(TypeName = "Date")]
    [Required]
    public DateTime priceChanged { get; init; }
    
    [Required]
    public double newPrice { get; init; }
}