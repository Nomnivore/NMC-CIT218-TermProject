using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Data
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        { }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Movie Night",
                    StartDateTime = DateTime.Parse("10/22/2022 20:00:00 -4:00"),
                    EndDateTime = DateTime.Parse("10/22/2022 23:00:00 -4:00"),
                    Location = "The movie theater",
                    Description = "Come watch an awesome movie with us!",
                    MaxAttendees = 50
                },

                new Event
                {
                    Id = 2,
                    Name = "CIT Conference",
                    StartDateTime = DateTime.Parse("10/26/2022 11:00:00 -4:00"),
                    EndDateTime = DateTime.Parse("10/28/2022 20:00:00 -4:00"),
                    Location = "Large conference hall in Big City",
                    Description = "A 3-day event loaded with speakers, Q&A's, networking opportunities, and more! You won't want to miss this.",
                }
            );
        }
    }
}
