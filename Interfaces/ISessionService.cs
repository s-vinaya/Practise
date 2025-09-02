using SamplePractice.Models;

namespace SamplePractice.Interfaces
{
    public interface ISessionService
    {
        Task<Session> CreateSessionAsync(Session session);
        Task<IEnumerable<Session>> GetSessionsByEventIdAsync(int eventId);
    }
}
