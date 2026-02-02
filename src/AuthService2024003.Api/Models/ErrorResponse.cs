using System.Diagnostics;

namespace AuthService2024003.Api.Models;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Detial { get; set; } = string.Empty;
    public string ErrorCode { get; set; } = string.Empty;
    public string TraceId { get; set; } = Activity.Current?.Id ?? string.Empty;
    public DateTime Timetamps { get; set; } = DateTime.UtcNow;
}

    