using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public record Book {
    [Key]
    public int id { get; init; }

    [Required]
    public string name { get; init; }
    
    public Publisher publisher { get; init; }
    
    public Category category { get; init; }
}