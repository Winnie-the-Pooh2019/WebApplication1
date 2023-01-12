using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record Store {
    [Key] [ForeignKey("book")] public int bookId { get; init; }
    
    public Book? book { get; init; }
    
    [Required]
    public int booksCount { get; set; }
    
    public PriceChange? price { get; init; }

    public int priceChangeId { get; set; }
}