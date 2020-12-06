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
        [TestCase("aba")]
        [TestCase("aa")]
        public void Should_ThrowException_When_DuplicateYesTo(string yesTo)
        {
            Assert.Throws<ArgumentException>(() => new IndividualsResponse(yesTo));
        }
        
        [Test]
        public void Should_ThrowException_When_UppercaseYesTo()
        {
            foreach(var letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                Assert.Throws<ArgumentException>(() => new IndividualsResponse(letter.ToString()));
        }
        
        [Test]
        [TestCase("abc", new object[]{'a','b','c'})]
        [TestCase("acb", new object[]{'a','b','c'})]
        [TestCase("abcxyz", new object[]{'a','b','c','x','y','z'})]
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