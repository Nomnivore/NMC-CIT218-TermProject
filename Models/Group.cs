using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace TermProject.Models
{
    public class Group
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters long")]
        [StringLength(50, ErrorMessage = "Name must not be longer than 50 characters")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Name must be alphanumeric")]
        public string Name { get; set; }

        // Foreign key to Group Owner (User) here

        [StringLength(500)]
        public string? Description { get; set; }

        // whether other users can join the group or not.
        // when user model is implemented, only group members
        // can post events, but anyone can attend an event
        [Display(Name="Can Join?")]
        [Column("CanJoin")]
        [Required]
        public bool AllowJoin { get; set; }

        
    }
}
