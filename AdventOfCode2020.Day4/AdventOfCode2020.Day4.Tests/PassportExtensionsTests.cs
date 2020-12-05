using System;
using NUnit.Framework;

namespace AdventOfCode2020.Day4.Tests
{
    public class PassportExtensionsTests
    {
        [Test]
        public void Should_ThrowException_When_NullPassport()
        {
            Passport sut = null;
            
            Assert.Throws<ArgumentNullException>(() => sut.Validate());
        }
  
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnFalse_When_InvalidBirthYear(string birthYear)
        {
            var sut = new Passport
            {
                BirthYear = birthYear,
                CountryId = "aaa",
                ExpirationYear = "aaa",
                EyeColor = "aaa",
                Height = "aaa",
                HairColor = "aaa",
                IssueYear = "aaa",
                PassportId = "aaa"
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnTrue_When_InvalidCountryId(string countryId)
        {
            var sut = new Passport
            {
                BirthYear = "aaa",
                CountryId = countryId,
                ExpirationYear = "aaa",
                EyeColor = "aaa",
                Height = "aaa",
                HairColor = "aaa",
                IssueYear = "aaa",
                PassportId = "aaa"
            };
            
            Assert.That(sut.Validate() == true);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnFalse_When_InvalidExpirationYear(string expirationYear)
        {
            var sut = new Passport
            {
                BirthYear = "aaa",
                CountryId = "aaa",
                ExpirationYear = expirationYear,
                EyeColor = "aaa",
                Height = "aaa",
                HairColor = "aaa",
                IssueYear = "aaa",
                PassportId = "aaa"
            };
            
            Assert.That(sut.Validate() == false);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnFalse_When_InvalidEyeColor(string eyeColor)
        {
            var sut = new Passport
            {
                BirthYear = "aaa",
                CountryId = "aaa",
                ExpirationYear = "2050",
                EyeColor = eyeColor,
                Height = "aaa",
                HairColor = "aaa",
                IssueYear = "aaa",
                PassportId = "aaa"
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnFalse_When_InvalidHeight(string height)
        {
            var sut = new Passport
            {
                BirthYear = "aaa",
                CountryId = "aaa",
                ExpirationYear = "2050",
                EyeColor = "aaa",
                Height = height,
                HairColor = "aaa",
                IssueYear = "aaa",
                PassportId = "aaa"
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnFalse_When_InvalidHairColor(string hairColor)
        {
            var sut = new Passport
            {
                BirthYear = "aaa",
                CountryId = "aaa",
                ExpirationYear = "2050",
                EyeColor = "aaa",
                Height = "aaa",
                HairColor = hairColor,
                IssueYear = "aaa",
                PassportId = "aaa"
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnFalse_When_InvalidIssueYear(string issueYear)
        {
            var sut = new Passport
            {
                BirthYear = "aaa",
                CountryId = "aaa",
                ExpirationYear = "2050",
                EyeColor = "aaa",
                Height = "aaa",
                HairColor = "aaa",
                IssueYear = issueYear,
                PassportId = "aaa"
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ReturnFalse_When_InvalidPassportId(string passportId)
        {
            var sut = new Passport
            {
                BirthYear = "aaa",
                CountryId = "aaa",
                ExpirationYear = "2050",
                EyeColor = "aaa",
                Height = "aaa",
                HairColor = "aaa",
                IssueYear = "aaa",
                PassportId = passportId
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("a","a", "a","a","a","a","a","a")]
        [TestCase("a",null, "a","a","a","a","a","a")]
        public void Should_ReturnTrue_When_ValidPassport(string birthYear, string countryId, string expirationYear,
            string eyeColour, string height, string hairColour, string issueYear, string passportId)
        {
            var sut = new Passport
            {
                BirthYear = birthYear,
                CountryId = countryId,
                ExpirationYear = expirationYear,
                EyeColor = eyeColour,
                Height = height,
                HairColor = hairColour,
                IssueYear = issueYear,
                PassportId = passportId
            };
            
            Assert.That(sut.Validate() == true);
        }
    }
}