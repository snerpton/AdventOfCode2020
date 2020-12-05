using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode2020.Day4.Tests
{
    public class PassportParserTests
    {
        public class ParseTests
        {
            [Test]
            public void Should_ThrowException_When_PassportEntryNull()
            {
                Assert.Throws<ArgumentNullException>(() => PassportParser.Parse(null));
            }
            
            [Test]
            public void Should_ReturnEmptyCollection_When_PassportEntryEmpty()
            {
                var actualPassportCollection = 
                    PassportParser.Parse(Enumerable.Empty<string>().ToArray());
                
                Assert.That(!actualPassportCollection.Any());
            }

            [Test]
            public void Should_ReturnTwoPassports_When_TwoValidPassportStringProvided()
            {
                var validPassports = new []
                {
                    "ecl:aaa pid:aaa eyr:aaa hcl:aaa" + "byr:aaa iyr:aaa cid:aaa hgt:aaa",
                    "ecl:aaa pid:aaa eyr:aaa hcl:aaa" + "byr:aaa iyr:aaa cid:aaa hgt:aaa"
                };
                var sut = PassportParser.Parse(validPassports);
                
                Assert.That(sut.Count() == validPassports.Count());
            }
            
            [Test]
            public void Should_ReturnOnePassports_When_OneOfTwoValidPassportStringProvided()
            {
                var validPassports = new []
                {
                    "ecl:aaa pid:aaa eyr:aaa hcl:aaa" + "byr:aaa iyr:aaa cid:aaa hgt:aaa",
                    "AAA:aaa pid:aaa eyr:aaa hcl:aaa" + "byr:aaa iyr:aaa cid:aaa hgt:aaa"
                };
                var sut = PassportParser.Parse(validPassports);
                
                Assert.That(sut.Count() == 1);
            }
        }
        
        public class ParseSinglePassportTests
        {
            private readonly string _validPassportAsString =
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + "byr:1937 iyr:2017 cid:147 hgt:183cm";
            
            [Test]
            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            public void Should_ThrowException_WhenNullOrWhitespace(string passportAsString)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => PassportParser.ParseSinglePassport(passportAsString));
            }

            [Test]
            [TestCase("\r\n")]
            [TestCase("\n")]
            [TestCase("\r")]
            public void Should_ThrowException_WhenContainsEmptyLine(string newLine)
            {
                var passportWithEmptyLine = _validPassportAsString + newLine;

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                    PassportParser.ParseSinglePassport(passportWithEmptyLine));
            }

            [Test]
            [TestCase("aaa")]
            [TestCase("aaa:bbb")]
            [TestCase("aaa:")]
            [TestCase(":bbb")]
            public void Should_ThrowException_When_UnexpectedKey(string keyValue)
            {
                var passportWithInvalidKey = _validPassportAsString + " " + keyValue;

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                    PassportParser.ParseSinglePassport(passportWithInvalidKey));
            }

            [Test]
            public void Should_CreatePassword()
            {
                var expected = "aaa";
                var validPassport =
                    $"ecl:{expected} pid:{expected} eyr:{expected} hcl:{expected} byr:{expected} iyr:{expected} cid:{expected} hgt:{expected}";
                var result = PassportParser.ParseSinglePassport(validPassport);

                Assert.That(result.BirthYear == expected, $"Birth Year was {result.BirthYear} but expected {expected}");
                Assert.That(result.CountryId == expected, $"Country Id was {result.CountryId} but expected {expected}");
                Assert.That(result.ExpirationYear == expected,
                    $"Expiration Year was {result.ExpirationYear} but expected {expected}");
                Assert.That(result.EyeColor == expected, $"EyeColor was {result.EyeColor} but expected {expected}");
                Assert.That(result.HairColor == expected, $"HairColor was {result.HairColor} but expected {expected}");
                Assert.That(result.Height == expected, $"Height was {result.Height} but expected {expected}");
                Assert.That(result.IssueYear == expected, $"IssueYear was {result.IssueYear} but expected {expected}");
                Assert.That(result.PassportId == expected,
                    $"Passport Id was {result.PassportId} but expected {expected}");
            }
        }
    }
}