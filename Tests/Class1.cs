using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class Class1
    {
        [Fact]
        public void true_should_be_true()
        {
            true.Should().BeTrue();
        }
    }
}
