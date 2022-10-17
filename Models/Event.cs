using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Event
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Foreign key to Event Organizer (User) here

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(1, 9999)]
        public int? MaxAttendees { get; set; }

        // Group is optional
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

    }
}
