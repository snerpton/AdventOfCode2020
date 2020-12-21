using System;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2020.Day9.Tests
{
    public class FileParserTests
    {
        [Test]
        public void Should_ThrowException_When_NullFilePathAndName()
        {
            string filePathAndName = null;
            
            Assert.Throws<ArgumentNullException>(() => FileParser.Read(filePathAndName));
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void Should_ThrowException_When_EmptyFilePathAndName(string filePathAndName)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.Read(filePathAndName));
        }
        
        [Test]
        public void Should_ThrowException_When_CantReadInputFile()
        {
            string filePathAndName = "/dummy/path/that/does/not/exist.txt";

            Assert.Throws<DirectoryNotFoundException>(() => FileParser.Read(filePathAndName));
        }
    }
}