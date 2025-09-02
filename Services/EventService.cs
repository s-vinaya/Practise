// EventService.cs
using Microsoft.EntityFrameworkCore;
using SamplePractice.Data;
using SamplePractice.Interfaces;
using SamplePractice.Models;
using System;

public class EventService : IEventService
{
    private readonly EventContext _context;

    public EventService(EventContext context)
    {
        _context = context;
    }

    public async Task<Event> CreateEventAsync(Event ev)
    {
        _context.events.Add(ev);
        await _context.SaveChangesAsync();
        return ev;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.events.Include(e => e.Sessions).ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        return await _context.events.Include(e => e.Sessions)
                                    .FirstOrDefaultAsync(e => e.EventId == id);
    }

    public async Task<Event?> UpdateEventAsync(int id, Event ev)
    {
        var existing = await _context.events.FindAsync(id);
        if (existing == null) return null;

        existing.Title = ev.Title;
        existing.Description = ev.Description;
        existing.Date = ev.Date;
        existing.Location = ev.Location;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        var existing = await _context.events.FindAsync(id);
        if (existing == null) return false;

        _context.events.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
