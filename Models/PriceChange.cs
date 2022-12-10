using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("price_change")]
public record PriceChange {
    [Key]
    public int id { get; init; }
    
    [Column("price_changed", TypeName = "Date")]
    [Required]
    public DateTime priceChanged { get; init; }
    
    [Required]
    public double newPrice { get; init; }
}