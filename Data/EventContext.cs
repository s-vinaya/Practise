using Microsoft.EntityFrameworkCore;
using SamplePractice.Models;

namespace SamplePractice.Data
{
    public class EventContext:DbContext
    {
        public DbSet<Event> events { get; set; }
        public DbSet<Session> sessions { get; set; }
        public DbSet<Participant> participants { get; set; }
        public DbSet<SessionParticipant> sessionParticipants { get; set; }
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasKey(e => e.EventId);
            modelBuilder.Entity<Event>()
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Event>()
                .HasMany(e=> e.Sessions)
                .WithOne(s=>s.Event)
                .HasForeignKey(s=>s.EventId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Session>()
                .HasKey(s => s.SessionId);
            modelBuilder.Entity<Session>()
                .Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Participant>()
                                .HasKey(p => p.ParticipantId);
            modelBuilder.Entity<Participant>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Participant>()
                .HasIndex(p => p.Email)
                .IsUnique();
            modelBuilder.Entity<SessionParticipant>()
                .HasKey(sp => new { sp.SessionId, sp.ParticipantId });
            modelBuilder.Entity<SessionParticipant>()
                .HasOne(sp => sp.session)
                .WithMany(s => s.sessionParticipants)
                .HasForeignKey(sp => sp.SessionId);
            modelBuilder.Entity<SessionParticipant>()
                .HasOne(sp => sp.participant)
                .WithMany(p => p.sessionParticipants)
                .HasForeignKey(sp => sp.ParticipantId);

            modelBuilder.Entity<Session>().HasData(new Session
            {
                SessionId = 1,
                Title = "Introduction to C#",
                Speaker = "Alice Johnson",
                StartTime = DateTime.Parse("2023-10-01T09:00:00"),
                EndTime = DateTime.Parse("2023-10-01T10:30:00"),
                EventId = 1

            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 1,
                Title = "Tech Conference 2023",
                Description = "A conference about the latest in technology.",
                Date = DateTime.Parse("2023-10-01"),
                Location = "New York"
            });
            modelBuilder.Entity<Participant>().HasData(new Participant
            {
                ParticipantId = 1,
                Name = "John Doe",
                Email = "j@gmail.com",
                Phone = "1234567900"
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
