namespace WebApplication1.Data.Dto;

public record BookDto {
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string publisherName { get; set; } = string.Empty;
    public string categoryName { get; set; } = string.Empty;
}