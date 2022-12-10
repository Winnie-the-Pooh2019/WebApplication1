using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("purchase_item")]
public record PurchaseItem {
    [Key]
    public int id { get; init; }
    
    [ForeignKey("purchase_id")]
    public Purchase purchase { get; init; }
    
    [ForeignKey("book_id")]
    public Book book { get; init; }
    
    [Required]
    [Column("books_count")]
    public int booksCount { get; init; }
    
    [ForeignKey("current_price")]
    public PriceChange price { get; init; }
}