using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject_PurpleBuzz.ViewModel.TeamMembers
{
    public class TeamMemberUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        public string? PhotoName { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
