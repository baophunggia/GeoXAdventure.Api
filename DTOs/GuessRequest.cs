namespace GeoXAdventure.Api.DTOs;

public class GuessRequest
{
    public long TelegramId { get; set; }
    public double GuessLat { get; set; }
    public double GuessLng { get; set; }
}