using Microsoft.AspNetCore.Mvc;
using GeoXAdventure.Api.Models;
using GeoXAdventure.Api.DTOs;

namespace GeoXAdventure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private static readonly List<User> _users = new(); // Temporary in-memory, sau sẽ thay DB

    [HttpPost("auth")]
    public IActionResult Auth([FromBody] User user)
    {
        var existing = _users.FirstOrDefault(u => u.TelegramId == user.TelegramId);
        if (existing == null)
        {
            _users.Add(user);
            return Ok(new { message = "User created", user });
        }
        return Ok(new { message = "User exists", user = existing });
    }

    [HttpPost("guess")]
    public IActionResult SubmitGuess([FromBody] GuessRequest request)
    {
        var user = _users.FirstOrDefault(u => u.TelegramId == request.TelegramId);
        if (user == null) return NotFound("User not found");

        // Logic tính điểm giả lập (sẽ cải tiến sau)
        int score = 500; // Giả lập
        user.Points += score;

        return Ok(new { score, remainingLives = user.Lives, totalPoints = user.Points });
    }

    [HttpGet("user/{telegramId}")]
    public IActionResult GetUser(long telegramId)
    {
        var user = _users.FirstOrDefault(u => u.TelegramId == telegramId);
        return user != null ? Ok(user) : NotFound();
    }
}