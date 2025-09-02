
using Microsoft.EntityFrameworkCore;
using SamplePractice.Data;
using SamplePractice.Interfaces;
using SamplePractice.Models;
using System;

public class ParticipantService : IParticipantService
{
    private readonly EventContext _context;

    public ParticipantService(EventContext context)
    {
        _context = context;
    }

    public async Task<Participant> RegisterParticipantAsync(int sessionId, Participant participant)
    {
        var existing = await _context.participants.FirstOrDefaultAsync(p => p.Email == participant.Email);
        if (existing == null)
        {
            _context.participants.Add(participant);
            await _context.SaveChangesAsync();
            existing = participant;
        }

        // check if already registered
        bool alreadyRegistered = await _context.sessionParticipants
            .AnyAsync(sp => sp.SessionId == sessionId && sp.ParticipantId == existing.ParticipantId);

        if (!alreadyRegistered)
        {
            _context.sessionParticipants.Add(new SessionParticipant
            {
                SessionId = sessionId,
                ParticipantId = existing.ParticipantId
            });
            await _context.SaveChangesAsync();
        }

        return existing;
    }

    public async Task<IEnumerable<Participant>> GetParticipantsBySessionIdAsync(int sessionId)
    {
        return await _context.sessionParticipants
            .Where(sp => sp.SessionId == sessionId)
            .Include(sp => sp.participant)
            .Select(sp => sp.participant)
            .ToListAsync();
    }
}
