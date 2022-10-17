using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace TermProject.Models
{
    public class Group
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Foreign key to Group Owner (User) here

        [StringLength(500)]
        public string? Description { get; set; }

        // whether other users can join the group or not.
        // when user model is implemented, only group members
        // can post events, but anyone can attend an event
        [Required]
        public bool AllowJoin { get; set; }

        
    }
}
