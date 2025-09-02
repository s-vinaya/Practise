using System.ComponentModel.DataAnnotations;

namespace SamplePractice.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public ICollection<Session> Sessions { get; set; }=new List<Session>();

    }
}
