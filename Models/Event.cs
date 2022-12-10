using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Event
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters long")]
        [StringLength(50, ErrorMessage = "Name must not be longer than 50 characters")]
        [RegularExpression("^[a - zA - Z0 - 9_] *$", ErrorMessage = "Name must be alphanumeric")]
        public string Name { get; set; }

        // Foreign key to Event Organizer (User) here

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date/Time")]
        public DateTime StartDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date/Time")]
        public DateTime EndDateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(1, 9999)]
        [Display(Name = "Max Attendees")]
        public int? MaxAttendees { get; set; }

        // Group is optional
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

    }
}
