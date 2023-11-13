using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject_PurpleBuzz.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string? PhotoName { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }

    }
}
