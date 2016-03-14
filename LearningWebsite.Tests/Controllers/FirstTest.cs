using FluentAssertions;
using Xunit;

namespace LearningWebsite.Tests.Controllers
{
    class FirstTest
    {
       [Fact]
        public void true_should_be_true()
        {
            true.Should().BeTrue();
        }
    }
}
