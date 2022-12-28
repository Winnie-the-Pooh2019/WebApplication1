using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace WebApplication1.Data.Dto;

public record UserDto {
    public string login { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;
    public string role { get; set; } = string.Empty;
}