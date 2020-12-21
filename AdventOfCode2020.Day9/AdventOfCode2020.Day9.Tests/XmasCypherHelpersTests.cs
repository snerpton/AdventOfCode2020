using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day9.Tests
{
    public class XmasCypherHelpersTests
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

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Should_ThrowException_When_ZeroOrNagativePreamble(int preamble)
        {
            var inputLines = new long[] {1, 2, 3};
            var sut = new XmasCypherHelpers(inputLines);

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Validate(preamble, out var firstInvalidNumber));
        }
    }
}