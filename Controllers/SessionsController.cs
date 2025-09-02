
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamplePractice.Interfaces;
using SamplePractice.Models;

[ApiController]
[Route("api/[controller]")]
public class SessionsController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Session session)
    {
        var created = await _sessionService.CreateSessionAsync(session);
        return Ok(created);
    }

    [HttpGet("byevent/{eventId}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetByEvent(int eventId)
    {
        return Ok(await _sessionService.GetSessionsByEventIdAsync(eventId));
    }
}
