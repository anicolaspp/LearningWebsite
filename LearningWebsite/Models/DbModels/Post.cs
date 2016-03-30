using System;

namespace LearningWebsite.Models.DbModels
{
    public class Post
    {
        public int Id { get; set; }

        public virtual DiscusionBoard DiscusionBoard { get; set; }

        public DateTime DateAdded { get; set; }

        public string Content { get; set; }

        public virtual User PostedBy { get; set; }
    }
}