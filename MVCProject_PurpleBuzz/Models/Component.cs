﻿namespace MVCProject_PurpleBuzz.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImagePath { get; set; }

        public List<Category> Categories { get; set; }
    }
}
