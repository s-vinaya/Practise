namespace SamplePractice.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public ICollection<SessionParticipant> sessionParticipants { get; set; }=new List<SessionParticipant>();


    }
}
