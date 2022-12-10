using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("deliveries")]
public record Delivery {
    [Key]
    public int id { get; init; }
    
    [ForeignKey("book_id")]
    public Book book { get; init; }

    [Required] [Column("delivery_date", TypeName = "Date")]
    public DateTime deliveryDate { get; init; }
    
    [Required]
    [Column("books_count")]
    public int booksCount { get; init; }
    
    [Required]
    public double price { get; init; }
}