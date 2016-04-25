using System;

namespace LearningWebsite.Models.Db.Models
{
    public class Post
    {
        public int Id { get; set; }

        public virtual DiscusionBoard DiscusionBoard { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public string Content { get; set; }

        public virtual User PostedBy { get; set; }
    }
}