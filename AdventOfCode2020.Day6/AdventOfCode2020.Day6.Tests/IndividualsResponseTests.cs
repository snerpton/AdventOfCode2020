using System;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day6.Tests
{
    public class IndividualsResponseTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Should_ThrowException_When_NullOrEmptyYesTo(string yesNo)
        {
            Assert.Throws<ArgumentNullException>(() => new IndividualsResponse(yesNo));
        }
    
        [Test]
        [TestCase("ABA")]
        [TestCase("AA")]
        public void Should_ThrowException_When_DuplicateYesTo(string yesTo)
        {
            Assert.Throws<ArgumentException>(() => new IndividualsResponse(yesTo));
        }
        
        [Test]
        public void Should_ThrowException_When_LowercaseYesTo()
        {
            foreach(var letter in "abcdefghijklmnopqrstuvwxyz")
                Assert.Throws<ArgumentException>(() => new IndividualsResponse(letter.ToString()));
        }
        
        [Test]
        [TestCase("ABC", new object[]{'A','B','C'})]
        [TestCase("ACB", new object[]{'A','B','C'})]
        [TestCase("ABCXYZ", new object[]{'A','B','C','X','Y','Z'})]
        public void Should_PopulateYesTo_When_ValidYesTo(string yesTo, object[] expectedYesToObj)
        {
            var expectedYesTo = expectedYesToObj.Select(x => x.ToString()[0]).ToArray();
            var sut = new IndividualsResponse(yesTo);
            
            
            Assert.That(sut.YesTo.Length == yesTo.Length, $"input ({sut.YesTo.Length}) and output ({yesTo.Length}) different lengths.");
            for (var index=0; index<sut.YesTo.Length; index++)
            {
                Assert.That(sut.YesTo[index] == expectedYesTo[index], $"sut YesTo ({sut.YesTo[index]}) does not equal expected yesTo ({expectedYesTo[index]}) ");
            }
        }
    }
}