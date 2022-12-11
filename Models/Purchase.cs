using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public record Purchase {
    [Key]
    public int id { get; init; }
    
    public Customer customer { get; init; }

    [Required] 
    [Column(TypeName = "Date")]
    public DateTime purchaseDate { get; init; }
};