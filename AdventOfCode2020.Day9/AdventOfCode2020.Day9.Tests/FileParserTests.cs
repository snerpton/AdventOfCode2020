using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var filePathAndName = "/dummy/path/that/does/not/exist.txt";

            Assert.Throws<DirectoryNotFoundException>(() => FileParser.Read(filePathAndName));
        }

        [Test]
        public void Should_ThrowException_When_NullInputLines()
        {
            IEnumerable<string> inputLines = null;

            Assert.Throws<ArgumentNullException>(() => FileParser.Parse(inputLines));
        }
        
        [Test]
        public void Should_ThrowException_When_EmptyInputLines()
        {
            var inputLines = Enumerable.Empty<string>();

            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.Parse(inputLines));
        }

        [Test]
        public void Should_ParseInputLines_When_ValidInput()
        {
            var inputLines = new[] {"1", "2", "3", "12"};
            var expectedLines = new [] {1, 2, 3, 12};

            var actualLines = FileParser.Parse(inputLines);
            
            Assert.That(actualLines, Is.EqualTo(expectedLines));
        }
    }
}