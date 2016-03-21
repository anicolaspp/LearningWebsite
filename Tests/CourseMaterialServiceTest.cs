using FluentAssertions;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Implementations;
using Xunit;
using NSubstitute;

namespace Tests
{
    public class CourseMaterialServiceTest
    {
        [Fact]
        public void course_material_should_have_rating_cero_when_no_ratings()
        {
            var repo = Substitute.For<ICourseMaterialRepository>();
            repo.GetBy(5).Returns(new CourseMaterial
            {
                Title = "aMaterial",
                Rating = 0,
                Content = "aContent",
                Id = 5
            });

            var service = new CourseMaterialService(repo, null);

            var cm = service.GetBy(5);

            cm.Rating.Should().Be(0);
            cm.Title.Should().Be("aMaterial");
            cm.Content.Should().Be("aContent");
        }

        [Fact]
        public void course_material_should_have_rating_when_have_been_rated()
        {
            var repo = Substitute.For<ICourseMaterialRepository>();
            repo
                .GetRatingsFor(5)
                .Returns(new []
                {1,5
                }
                );

            repo.GetBy(5).Returns(new CourseMaterial
            {
                Title = "aMaterial",
                Rating = 0,
                Content = "aContent",
                Id = 5
            });

            var service = new CourseMaterialService(repo, null);

            var cm = service.GetBy(5);

            cm.Rating.Should().Be(3);
        }

        [Fact]
        public void service_should_return_null_when_cm_not_found()
        {
            var repo = Substitute.For<ICourseMaterialRepository>();
            var service = new CourseMaterialService(repo, null);

            var cm = service.GetBy(5);

            cm.Should().BeNull();
        }
    }
}