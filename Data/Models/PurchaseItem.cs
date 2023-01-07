using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record PurchaseItem {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; init; }
    
    public Purchase purchase { get; init; }
    
    public int purchaseId { get; set; }
    
    public Book book { get; init; }
    
    public int bookId { get; set; }
    
    [Required]
    public int booksCount { get; set; }
    
    public PriceChange price { get; init; }
    
    public int priceId { get; set; }
}