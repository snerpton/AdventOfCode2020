using System;
using NUnit.Framework;

namespace AdventOfCode2020.Day10.Tests
{
    public class FileParserTests
    {
        [Test]
        public void Should_ThrowException_When_NullFileParameter()
        
        {
            string filePathAndName = null;
            
            Assert.Throws<ArgumentNullException>(() => FileParser.Read(filePathAndName));
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void Should_ThrowException_When_EmptyFileParameter(string filePathAndName)
        
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.Read(filePathAndName));
        }
    }
}