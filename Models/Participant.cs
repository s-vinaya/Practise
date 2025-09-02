using System.ComponentModel.DataAnnotations;

namespace SamplePractice.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<SessionParticipant> sessionParticipants { get; set; } = new List<SessionParticipant>();
    }
}
