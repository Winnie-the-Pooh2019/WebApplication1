using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("books")]
public record Book {
    [Key]
    public int id { get; init; }

    [Required]
    public string name { get; init; }
    
    [ForeignKey("publisher_id")]
    public Publisher publisher { get; init; }
    
    [ForeignKey("category_id")]
    public Category category { get; init; }
}