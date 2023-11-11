namespace MVCProject_PurpleBuzz.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImagePath { get; set; }

        public List<CategoryComponent> CategoryComponents { get; set; } = new List<CategoryComponent>();

    }
}
