using SamplePractice.Models;

namespace SamplePractice.Interfaces
{
    public interface IEventService
    {
        Task<Event> CreateEventAsync(Event ev);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task<Event?> UpdateEventAsync(int id, Event ev);
        Task<bool> DeleteEventAsync(int id);
    }
}
