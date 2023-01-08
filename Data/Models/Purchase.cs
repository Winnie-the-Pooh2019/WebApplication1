using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record Purchase {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; init; }
    
    public Customer? customer { get; init; }

    public int customerId { get; set; }

    [Required] 
    [Column(TypeName = "Date")]
    public DateTime purchaseDate { get; set; }
};