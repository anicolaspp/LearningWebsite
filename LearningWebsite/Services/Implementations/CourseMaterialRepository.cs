using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using WebGrease.Css.Extensions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseMaterialRepository : ICourseMaterialRepository
    {
        private readonly WebSiteDbContext context = new WebSiteDbContext();

        public ICollection<int> GetRatingsFor(int id)
        {
            return context
                .CourseMaterialUserRantings
                .Where(ranting => ranting.CourseMaterialId == id)
                .Select(cm => cm.Rating).ToList();
        }

        public CourseMaterial GetBy(int id)
        {
            var cm = context.CourseMaterials.Find(id);

            return cm;
        }

        public IEnumerable<CourseMaterial> GetCourseThatMatchName(string name)
        {
            var courseMaterialThatMatches = context.CourseMaterials.Where(material => material.Content == name);

            return courseMaterialThatMatches;
        }

        public int Add(CourseMaterial courseMaterial)
        {
            try
            {
                context.CourseMaterials.Add(courseMaterial);

                var existingTags = context.Tags.Where(tag => courseMaterial.Tags.Contains(tag.Name)).ToList();

                existingTags.ForEach(tag =>
                {
                    tag.CourseMaterials.Add(courseMaterial);
                    context.Tags.AddOrUpdate(tag);
                });

                var newTags = courseMaterial.Tags.Where(tag =>
                {
                    var ex = existingTags.Select(t => t.Name);

                    return ex.Contains(tag) == false;
                });

                newTags.ForEach(tag =>
                {
                    context.Tags.Add(new Tag {Name = tag, CourseMaterials = new List<CourseMaterial> {courseMaterial}});
                });

                context.SaveChanges();

                return courseMaterial.Id;
            }

            catch (Exception ex)
            {

                return -1;
            }
        }
    }
}