using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record Delivery {
    [Key]
    public int id { get; init; }
    
    public Book book { get; init; }

    [Required] 
    [Column(TypeName = "Date")]
    public DateTime deliveryDate { get; init; }
    
    [Required]
    public int booksCount { get; init; }
    
    [Required]
    public double price { get; init; }
}