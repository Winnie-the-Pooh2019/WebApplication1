using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OpenApi.Services;

namespace WebApplication1.Models;

[Table("store")]
public record Store {
    [Key]
    [ForeignKey("book_id")]
    public Book book { get; init; }
    
    [Required]
    [Column("books_count")]
    public int booksCount { get; init; }
    
    [ForeignKey("current_price")]
    public PriceChange price { get; init; }
}