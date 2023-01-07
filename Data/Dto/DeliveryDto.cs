namespace WebApplication1.Data.Dto;

public record DeliveryDto {
    public int bookId { get; set; }
    public string date { get; set; } = string.Empty;
    public int booksCount { get; set; }
    public double price { get; set; }
}