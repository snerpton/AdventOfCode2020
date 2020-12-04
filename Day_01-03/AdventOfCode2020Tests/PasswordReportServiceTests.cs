using System;
using System.Collections.Generic;
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

        public class NumberOfInvalidPasswordsTests
        {
            [Test]
            public void Should_Return0InValidPasswordCount_When_0InValid()
            {
                var pwEntry1 = new PasswordEntry{Password = "abb", PwPolicy = new PasswordPolicy{ Letter = 'a', Position1 = 1, Position2 = 2}};
                var pwEntry2 = new PasswordEntry{Password = "bab", PwPolicy = new PasswordPolicy{ Letter = 'a', Position1 = 1, Position2 = 2}};
                var pwEntry3 = new PasswordEntry{Password = "bba", PwPolicy = new PasswordPolicy{ Letter = 'b', Position1 = 1, Position2 = 3}};
                var pwEntries = new List<PasswordEntry> {pwEntry1, pwEntry2, pwEntry3};

                var sut = new PasswordReportService(pwEntries);
                var validCount = sut.NumberOfValidPasswords();
                
                Assert.That(validCount == 3);
            }
            
            [Test]
            public void Should_Return1InValidPasswordCount_When_1InValid()
            {
                var pwEntry1 = new PasswordEntry{Password = "aab", PwPolicy = new PasswordPolicy{ Letter = 'a', Position1 = 1, Position2 = 2}}; // not valid
                var pwEntry2 = new PasswordEntry{Password = "bab", PwPolicy = new PasswordPolicy{ Letter = 'a', Position1 = 1, Position2 = 2}};
                var pwEntry3 = new PasswordEntry{Password = "bba", PwPolicy = new PasswordPolicy{ Letter = 'b', Position1 = 1, Position2 = 3}};
                var pwEntries = new List<PasswordEntry> {pwEntry1, pwEntry2, pwEntry3};

                var sut = new PasswordReportService(pwEntries);
                var validCount = sut.NumberOfValidPasswords();
                
                Assert.That(validCount == 2);
            }
            
            [Test]
            public void Should_Return2InValidPasswordCount_When_2InValid()
            {
                var pwEntry1 = new PasswordEntry{Password = "aab", PwPolicy = new PasswordPolicy{ Letter = 'a', Position1 = 1, Position2 = 2}}; // not valid
                var pwEntry2 = new PasswordEntry{Password = "bba", PwPolicy = new PasswordPolicy{ Letter = 'a', Position1 = 1, Position2 = 2}}; // not valid
                var pwEntry3 = new PasswordEntry{Password = "bba", PwPolicy = new PasswordPolicy{ Letter = 'b', Position1 = 1, Position2 = 3}};
                var pwEntries = new List<PasswordEntry> {pwEntry1, pwEntry2, pwEntry3};

                var sut = new PasswordReportService(pwEntries);
                var validCount = sut.NumberOfValidPasswords();
                
                Assert.That(validCount == 1);
            }
        }
        
        
        public class ValidatePasswordTests
        {
            [Test]
            [TestCase("1-3 a: abcde", true)]
            [TestCase("1-3 c: abcde", true)]
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
            [TestCase("2-9 c: ccccccccc", false)]
            [TestCase("1-3 c: abade", false)]
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