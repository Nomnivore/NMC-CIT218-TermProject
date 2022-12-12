using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class EventAttendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Event")]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }

        public virtual Event? Event { get; set; }
        public virtual IdentityUser? User { get; set; }

        [Required]
        public StatusEnum Status { get; set; }
    }

    public enum StatusEnum
    {
        Yes,
        Maybe,
        No
    }
}
