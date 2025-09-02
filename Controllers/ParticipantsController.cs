
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamplePractice.Interfaces;
using SamplePractice.Models;

[ApiController]
[Route("api/[controller]")]
public class ParticipantsController : ControllerBase
{
    private readonly IParticipantService _participantService;

    public ParticipantsController(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpPost("register")]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> Register(int sessionId, Participant participant)
    {
        var registered = await _participantService.RegisterParticipantAsync(sessionId, participant);
        return Ok(registered);
    }

    [HttpGet("bysession/{sessionId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetBySession(int sessionId)
    {
        return Ok(await _participantService.GetParticipantsBySessionIdAsync(sessionId));
    }
}
