using System;
using AdventOfCode2020.Models;
using AdventOfCode2020.Repositories;
using AdventOfCode2020.Services;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    public class PasswordReportServiceTests
    {
        private class PasswordRepositoryTestWrapper : PasswordRepository
        {
            public new PasswordEntry PasswordEntryFromFileLine(string line) => base.PasswordEntryFromFileLine(line);
        }
        
        [Test]
        public void Should_ThrowException_When_NullPasswordReport()
        {
            Assert.Throws<ArgumentNullException>(() => new PasswordReportService(null));
        }

        public class ValidatePasswordTests
        {
            [Test]
            [TestCase("1-3 a: abcde", true)]
            [TestCase("2-9 c: ccccccccc", true)]
            public void Should_ReturnTrue_When_ValidPassword(string passwordEntryAsString, bool expectedValid)
            {
                var passwordRepository = new PasswordRepositoryTestWrapper();
                var passwordEntry = passwordRepository.PasswordEntryFromFileLine(passwordEntryAsString);

                var sut = new PasswordReportService();
                var actualValid = sut.ValidatePassword(passwordEntry);
                
                Assert.That(actualValid == expectedValid);
            }
            
            [Test]
            [TestCase("1-3 b: cdefg", false)]
            [TestCase("2-1 b: bbb", false)]
            [TestCase("1-2 a: bbb", false)]
            [TestCase("1-2 b: bbb", false)]
            public void Should_ReturnFalse_When_InValidPassword(string passwordEntryAsString, bool expectedValid)
            {
                var passwordRepository = new PasswordRepositoryTestWrapper();
                var passwordEntry = passwordRepository.PasswordEntryFromFileLine(passwordEntryAsString);

                var sut = new PasswordReportService();
                var actualValid = sut.ValidatePassword(passwordEntry);
                
                Assert.That(actualValid == expectedValid);
            }
        }
        
        
    }
}