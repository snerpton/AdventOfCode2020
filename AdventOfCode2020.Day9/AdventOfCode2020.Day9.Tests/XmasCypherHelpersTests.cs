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
        public void Should_ThrowException_When_ZeroOrNegativePreamble(int preamble)
        {
            var inputLines = new long[] {1, 2, 3};
            var sut = new XmasCypherHelpers(inputLines);

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Validate(preamble, out var firstInvalidNumber));
        }

        [Test]
        public void Should_Validate_When_ValidInput()
        {
            var inputLines = new long[] {35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182};
            var preamble = 5;
            var sut = new XmasCypherHelpers(inputLines);
            
            Assert.That(sut.Validate(preamble, out var firstInvalidNumber), Is.EqualTo(true));
        }
        
        [Test]
        public void Should_NotValidate_When_InvalidInput()
        {
            var inputLines = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576
            };
            var preamble = 5;
            var sut = new XmasCypherHelpers(inputLines);
            
            Assert.That(sut.Validate(preamble, out var firstInvalidNumber), Is.EqualTo(false));
        }
        
        [Test]
        public void Should_FindFirstInvalidNumber_When_InvalidInput()
        {
            var inputLines = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576
            };
            var preamble = 5;
            var sut = new XmasCypherHelpers(inputLines);

            sut.Validate(preamble, out var actualFirstInvalidNumber);
            var expectedFirstInvalidNumber = 127;

            Assert.That(actualFirstInvalidNumber == expectedFirstInvalidNumber);
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Should_ThrowException_When_ZeroOrNegativeTarget(long target)
        {
            var inputLines = new long[] {1, 2, 3};
            var preamble = 1;
            var sut = new XmasCypherHelpers(inputLines);

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.FindContiguousSetAddingUpTo(target));
        }
        
        [Test]
        public void Should_FindContiguousSetAddingUpTo_When_ValidInput()
        {
            var inputLines = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576
            };
            const long target = 127;
            var expectedSet = new long[] {15, 25, 47, 40};
            
            var sut = new XmasCypherHelpers(inputLines);
            

            Assert.That(sut.FindContiguousSetAddingUpTo(target), Is.EqualTo(expectedSet));
        }
    }
}