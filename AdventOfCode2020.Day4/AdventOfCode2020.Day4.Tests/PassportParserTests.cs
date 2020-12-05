using System;
using NUnit.Framework;

namespace AdventOfCode2020.Day4.Tests
{
    public class PassportParserTests
    {
        private readonly string _validPassportAsString =
            "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + "byr:1937 iyr:2017 cid:147 hgt:183cm";

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_ThrowException_WhenNullOrWhitespace(string passportAsString)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => PassportParser.Parse(passportAsString));
        }
        
        [Test]
        [TestCase("\r\n")]
        [TestCase("\n")]
        [TestCase("\r")]
        public void Should_ThrowException_WhenContainsEmptyLine(string newLine)
        {
            var passportWithEmptyLine = _validPassportAsString + newLine;

            Assert.Throws<ArgumentOutOfRangeException>(() => PassportParser.Parse(passportWithEmptyLine));
        }
        
        [Test]
        [TestCase("aaa")]
        [TestCase("aaa:bbb")]
        [TestCase("aaa:")]
        [TestCase(":bbb")]
        public void Should_ThrowException_When_UnexpectedKey(string keyValue)
        {
            var passportWithInvalidKey = _validPassportAsString + " " + keyValue;
            
            Assert.Throws<ArgumentOutOfRangeException>(() => PassportParser.Parse(passportWithInvalidKey));
        }

        [Test]
        public void Should_CreatePassword()
        {
            var validPassport = "ecl:aaa pid:aaa eyr:aaa hcl:aaa byr:aaa iyr:aaa cid:aaa hgt:aaa";
            var result = PassportParser.Parse(validPassport );
            
            Assert.That(result.BirthYear == "aaa");
            Assert.That(result.CountryId == "aaa");
            Assert.That(result.ExpirationYear == "aaa");
            Assert.That(result.EyeColor == "aaa");
            Assert.That(result.HairColor == "aaa");
            Assert.That(result.Height == "aaa");
            Assert.That(result.IssueYear == "aaa");
            Assert.That(result.PassportId == "aaa");
        }
    }
}