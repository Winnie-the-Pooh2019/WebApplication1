namespace WebApplication1.Data.Dto; 

public record PurchaseItemDto {
    public int purchaseId { get; set; }
    public int bookId { get; set; }
    public int booksCount { get; set; }
    public int priceId { get; set; }
}