using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models;

public record Book {
    [Key]
    public int id { get; init; }

    [Required]
    public string name { get; init; }
    
    public Publisher publisher { get; init; }
    
    public Category category { get; init; }
}