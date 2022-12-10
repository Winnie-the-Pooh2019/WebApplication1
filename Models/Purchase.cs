using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("purchases")]
public record Purchase {
    [Key]
    public int id { get; init; }
    
    [ForeignKey("customer_id")]
    public Client customerId { get; init; }

    [Required] [Column("purchase_date", TypeName = "Date")]
    public DateTime purchaseDate { get; init; }
};