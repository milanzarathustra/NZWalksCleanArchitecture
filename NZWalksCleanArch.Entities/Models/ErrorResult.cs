namespace NZWalksCleanArch.Entities.Models;

public sealed class ErrorResult
{
    public IList<string>? Messages { get; set; }

    public string? Source { get; set; }
    public string? Exception { get; set; }
    public string? ErrorId { get; set; }
    public string? SupportMessage { get; set; }
    public int StatusCode { get; set; }
}
