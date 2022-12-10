using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Data
{
    // TODO: Extend IdentityDbContext and replace ApplicationDbContext
    // in order to model relationship between EventAttendance and IdentityUser
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<EventAttendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Group>().HasData(
                new Group
                {
                    Id = 1,
                    Name = "Comp Info Tech",
                    Description = "The best events to learn about all things CIT & network with your peers!",
                    AllowJoin = true,
                },

                new Group
                {
                    Id = 2,
                    Name = "PizzaSocial",
                    Description = "It should be known - where there's us, there's pizza.",
                    AllowJoin = true,
                },

                new Group
                {
                    Id = 3,
                    Name = "Movie Madness",
                    Description = "Live sleep breathe popcorn",
                    AllowJoin = true,
                }
            );

            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Movie Night",
                    StartDateTime = DateTime.Parse("10/22/2022 20:00:00 -4:00"),
                    EndDateTime = DateTime.Parse("10/22/2022 23:00:00 -4:00"),
                    Location = "The movie theater",
                    Description = "Come watch an awesome movie with us!",
                    MaxAttendees = 50,
                    GroupId = 3,
                },

                new Event
                {
                    Id = 2,
                    Name = "CIT Conference",
                    StartDateTime = DateTime.Parse("10/26/2022 11:00:00 -4:00"),
                    EndDateTime = DateTime.Parse("10/28/2022 20:00:00 -4:00"),
                    Location = "Large conference hall in Big City",
                    Description = "A 3-day event loaded with speakers, Q&A's, networking opportunities, and more! You won't want to miss this.",
                    GroupId = 1,
                }
            );

            builder.Entity<EventAttendance>()
                .HasKey(e => new { e.EventId, e.UserId });
        }
    }
}
