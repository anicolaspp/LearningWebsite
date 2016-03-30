using System;
using System.Collections.Generic;

namespace LearningWebsite.Models.DbModels
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<CourseMaterial> CourseMaterials { get; set; }

        public virtual DiscusionBoard DiscusionBoard { get; set; }
    }

    public class DiscusionBoard
    {
        public int Id { get; set; }

       // public virtual Course Course { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }

        public virtual DiscusionBoard DiscusionBoard { get; set; }

        public DateTime DateAdded { get; set; }

        public string Content { get; set; }
    }
}