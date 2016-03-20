using System.Linq;
using FluentAssertions;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Implementations;
using Xunit;

namespace Tests
{
    public class TagRepositoryTest
    {
        [Fact]
        public void repositoy_should_return_tags_with_name()
        {
            var respository = new TagRepository();

            var context = new WebSiteDbContext();
            context.Tags.Add(new Tag { Name = "aTag"});
            context.Tags.Add(new Tag {Name = "Tag p"});

            context.SaveChanges();

            var tags = respository.GetMatchesTo("tag").ToList();

            tags[0].Name.Should().Be("aTag");
            tags[1].Name.Should().Be("Tag p");


            context.Tags.Remove(context.Tags.Find(tags[0].Id));
            context.Tags.Remove(context.Tags.Find(tags[1].Id));
            context.SaveChanges();
        }
    }
}