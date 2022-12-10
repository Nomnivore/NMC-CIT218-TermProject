using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    // TODO: Run migrations and scaffold for this model AFTER merging DbContexts
    public class EventAttendance
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual Event Event { get; set; }
        public virtual IdentityUser User { get; set; }

        public StatusEnum Status { get; set; }
    }

    public enum StatusEnum
    {
        Yes,
        Maybe,
        No
    }
}
