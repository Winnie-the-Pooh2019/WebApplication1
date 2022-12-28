using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record Book {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; init; }

    [Required]
    public string name { get; init; }
    
    public Publisher publisher { get; init; }
    
    public Category category { get; init; }
}