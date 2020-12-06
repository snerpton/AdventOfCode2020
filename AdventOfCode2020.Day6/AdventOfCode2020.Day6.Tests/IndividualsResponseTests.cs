using System;
using NUnit.Framework;

namespace AdventOfCode2020.Day6.Tests
{
    public class IndividualsResponseTests
    {
        [Test]
        public void Should_ThrowException_When_NullYesTo()
        {
            Assert.Throws<ArgumentNullException>(() => new IndividualsResponse(null));
        }
    }
}