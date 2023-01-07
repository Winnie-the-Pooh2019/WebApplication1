namespace WebApplication1.Data.Dto; 

public record PurchaseDto {
    public int customerId { get; set; }
    public string purchaseDate { get; set; } = string.Empty;
}