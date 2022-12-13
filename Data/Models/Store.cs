using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record Store {
    [Key]
    [ForeignKey("book")]
    public int bookId { get; init; }
    
    public Book book { get; init; }
    
    [Required]
    public int booksCount { get; init; }
    
    public PriceChange price { get; init; }
}