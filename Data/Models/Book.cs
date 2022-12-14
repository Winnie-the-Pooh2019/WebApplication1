using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record Book {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; init; }

    [Required]
    public string name { get; set; }
    
    public Publisher? publisher { get; set; }

    public int publisherId { get; set; }
    
    public Category? category { get; set; }

    public int categoryId { get; set; }
}