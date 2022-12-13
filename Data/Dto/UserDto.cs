namespace WebApplication1.Data.Dto;

public record UserDto {
    public string name { get; set; }
    public string role { get; set; } = string.Empty;
}