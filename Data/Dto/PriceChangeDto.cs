namespace WebApplication1.Data.Dto;

public record PriceChangeDto {
    public double newPrice { get; set; }
    public string date { get; set; } = string.Empty;
}