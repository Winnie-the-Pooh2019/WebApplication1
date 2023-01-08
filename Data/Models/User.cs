using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public record User {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    public string loginName { get; set; }
    
    [Required]
    public string password { get; set; }
    
    [Required] 
    public string firstName { get; set; }
    
    [Required]
    public string lastName { get; set; }

    [Required]
    public string role { get; set; }
    
    public string salt { get; set; }
};