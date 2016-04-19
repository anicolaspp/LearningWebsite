using System;
using System.Collections.Generic;

namespace LearningWebsite.Models.DbModels
{
    public class DiscusionBoard
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        // public virtual Course Course { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}