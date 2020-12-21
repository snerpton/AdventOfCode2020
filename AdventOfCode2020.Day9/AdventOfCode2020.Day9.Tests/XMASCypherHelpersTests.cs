using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day9.Tests
{
    public class XMASCypherHelpersTests
    {
        [Test]
        public void Should_ThrowException_When_NullInput()
        {
            IEnumerable<long> input = null;

            Assert.Throws<ArgumentNullException>(() => new XmasCypherHelpers(input));
        }
        
        [Test]
        public void Should_ThrowException_When_EmptyInput()
        {
            var input = Enumerable.Empty<long>();

            Assert.Throws<ArgumentOutOfRangeException>(() => new XmasCypherHelpers(input));
        }
    }
}