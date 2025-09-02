
using Microsoft.EntityFrameworkCore;
using SamplePractice.Data;
using SamplePractice.Interfaces;
using SamplePractice.Models;
using System;

public class SessionService : ISessionService
{
    private readonly EventContext _context;

    public SessionService(EventContext context)
    {
        _context = context;
    }

    public async Task<Session> CreateSessionAsync(Session session)
    {
        // validation: EndTime must be after StartTime
        if (session.EndTime <= session.StartTime)
            throw new ArgumentException("Session cannot end before it starts");

        _context.sessions.Add(session);
        await _context.SaveChangesAsync();
        return session;
    }

    public async Task<IEnumerable<Session>> GetSessionsByEventIdAsync(int eventId)
    {
        return await _context.sessions
            .Include(s => s.sessionParticipants)
            .ThenInclude(sp => sp.participant)
            .Where(s => s.EventId == eventId)
            .ToListAsync();
    }
}
