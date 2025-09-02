namespace SamplePractice.Models
{
    public class SessionParticipant
    {
        public int SessionId { get; set; }
        public Session session { get; set; }
        public int ParticipantId { get; set; }
        public Participant participant { get; set; }

    }
}
