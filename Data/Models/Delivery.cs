using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record Delivery {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; init; }
    
    public Book? book { get; set; }

    public int bookId { get; set; }

    [Required] 
    [Column(TypeName = "Date")]
    public DateTime deliveryDate { get; set; }
    
    [Required]
    public int booksCount { get; set; }
    
    [Required]
    public double price { get; set; }
}