using System.ComponentModel.DataAnnotations;

namespace MVCProject_PurpleBuzz.Models
{
    public class RecentWork
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required"), MinLength(3, ErrorMessage = "Minimum length must be 3")]
        public string Title { get; set; }
        public string Desc{ get; set; }
        public string ImagePath { get; set; }
    }
}
