
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamplePractice.Interfaces;
using SamplePractice.Models;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
  
    public async Task<ActionResult> Create(Event ev)
    {
        var created = await _eventService.CreateEventAsync(ev);
        return Ok(created);
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Event>>> GetAll()
    {
        return Ok(await _eventService.GetAllEventsAsync());
    }

    [HttpGet("{id}")]
    
    public async Task<ActionResult> GetById(int id)
    {
        var ev = await _eventService.GetEventByIdAsync(id);
        if (ev == null) return NotFound();
        return Ok(ev);
    }

    [HttpPut("{id}")]
  
    public async Task<ActionResult> Update(int id, Event ev)
    {
        var updated = await _eventService.UpdateEventAsync(id, ev);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
   
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _eventService.DeleteEventAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
