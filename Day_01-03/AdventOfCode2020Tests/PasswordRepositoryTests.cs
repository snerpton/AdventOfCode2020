using AdventOfCode2020.Models;
using AdventOfCode2020.Repositories;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    
    public class PasswordRepositoryTests
    {
        private class PasswordRepositoryTestWrapper : PasswordRepository
        {
            public new PasswordEntry PasswordEntryFromFileLine(string line) => base.PasswordEntryFromFileLine(line);
        }
    
        [Test]
        [TestCase("1-3 a: abcde", 1)]
        [TestCase("1-3 b: cdefg", 1)]
        [TestCase("2-9 c: ccccccccc", 2)]
        public void Should_ParseFileLineToPolicyMin_When_ValidLine(string line, int expectedResult)
        {
            var sut = new PasswordRepositoryTestWrapper();

            var passwordEntry = sut.PasswordEntryFromFileLine(line);
            
            Assert.That(passwordEntry.PwPolicy.Position1 == expectedResult);
        }
        
        [Test]
        [TestCase("1-3 a: abcde", 3)]
        [TestCase("1-3 b: cdefg", 3)]
        [TestCase("2-9 c: ccccccccc", 9)]
        public void Should_ParseFileLineToPolicyMax_When_ValidLine(string line, int expectedResult)
        {
            var sut = new PasswordRepositoryTestWrapper();

            var passwordEntry = sut.PasswordEntryFromFileLine(line);
            
            Assert.That(passwordEntry.PwPolicy.Position2 == expectedResult);
        }
        
        [Test]
        [TestCase("1-3 a: abcde", 'a')]
        [TestCase("1-3 b: cdefg", 'b')]
        [TestCase("2-9 c: ccccccccc", 'c')]
        public void Should_ParseFileLineToPolicyLetter_When_ValidLine(string line, char expectedResult)
        {
            var sut = new PasswordRepositoryTestWrapper();

            var passwordEntry = sut.PasswordEntryFromFileLine(line);
            
            Assert.That(passwordEntry.PwPolicy.Letter == expectedResult);
        }

        [Test]
        [TestCase("1-3 a: abcde", "abcde")]
        [TestCase("1-3 b: cdefg", "cdefg")]
        [TestCase("2-9 c: ccccccccc", "ccccccccc")]
        public void Should_ParseFileLineToPassword_When_ValidLine(string line, string expectedResult)
        {
            var sut = new PasswordRepositoryTestWrapper();

            var passwordEntry = sut.PasswordEntryFromFileLine(line);
            
            Assert.That(passwordEntry.Password == expectedResult);
        }
    }
}