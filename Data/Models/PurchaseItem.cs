using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models;

public record PurchaseItem {
    [Key]
    public int id { get; init; }
    
    public Purchase purchase { get; init; }
    
    public Book book { get; init; }
    
    [Required]
    public int booksCount { get; init; }
    
    public PriceChange price { get; init; }
}