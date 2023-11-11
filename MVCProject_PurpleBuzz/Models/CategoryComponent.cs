namespace MVCProject_PurpleBuzz.Models
{
    public class CategoryComponent
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }


    }
}
