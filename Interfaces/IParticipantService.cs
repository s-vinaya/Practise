using SamplePractice.Models;

namespace SamplePractice.Interfaces
{
    public interface IParticipantService
    {
        Task<Participant> RegisterParticipantAsync(int sessionId, Participant participant);
        Task<IEnumerable<Participant>> GetParticipantsBySessionIdAsync(int sessionId);
    }
}
