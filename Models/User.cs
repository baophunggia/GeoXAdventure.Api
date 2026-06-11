namespace GeoXAdventure.Api.Models;

public class User
{
    public long TelegramId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public int Points { get; set; } = 100;
    public int Lives { get; set; } = 3;
    public DateTime LastPlayed { get; set; } = DateTime.UtcNow;
}