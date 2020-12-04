using AdventOfCode2020.Extensions;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    public class StringExtensionsTests
    {
        public class OccurenceTests
        {
            [Test]
            public void Should_ReturnZero_When_NeedleNotFound()
            {
                string haystack = "abc";
                var sut = haystack.Occurence('z');

                Assert.That(sut == 0);
            }
            
            [Test]
            [TestCase("abc",'a', 1)]
            [TestCase("abac",'a', 2)]
            [TestCase("abaabaaba",'a', 6)]
            public void Should_ReturnCorrectCount_When_NeedleFound(string haystack, char needle, int expectedCount)
            {
                var sut = haystack.Occurence(needle);

                Assert.That(sut == expectedCount);
            }
        }
    }
}