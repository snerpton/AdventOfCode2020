using System;
using NUnit.Framework;

namespace AdventOfCode2020.Day4.Tests
{
    public class PassportExtensionsTests
    {
        private string _validBirthYear = "1920";
        private string _validExpirationYear = "2020";
        private string _validEyeColor = "amb";
        private string _validHairColor = "#123abc";
        private string _validHeight = "150cm";
        private string _validIssueYear = "2010";
        private string _validPassportId = "123456789";
        
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
        [TestCase("1919")]
        [TestCase("2003")]
        public void Should_ReturnFalse_When_InvalidBirthYear(string birthYear)
        {
            var sut = new Passport
            {
                BirthYear = birthYear,
                CountryId = "aaa",
                ExpirationYear = _validExpirationYear,
                EyeColor = _validEyeColor,
                Height = _validHeight,
                HairColor = _validHairColor,
                IssueYear = _validIssueYear,
                PassportId = _validPassportId
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
                BirthYear = _validBirthYear,
                CountryId = countryId,
                ExpirationYear = _validExpirationYear,
                EyeColor = _validEyeColor,
                Height = _validHeight,
                HairColor = _validHairColor,
                IssueYear = _validIssueYear,
                PassportId = _validPassportId
            };
            
            Assert.That(sut.Validate() == true);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("2019")]
        [TestCase("2031")]
        public void Should_ReturnFalse_When_InvalidExpirationYear(string expirationYear)
        {
            var sut = new Passport
            {
                BirthYear = _validBirthYear,
                CountryId = "aaa",
                ExpirationYear = expirationYear,
                EyeColor = _validEyeColor,
                Height = _validHeight,
                HairColor = _validHairColor,
                IssueYear = _validIssueYear,
                PassportId = _validPassportId
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
                BirthYear = _validBirthYear,
                CountryId = "aaa",
                ExpirationYear = _validExpirationYear,
                EyeColor = eyeColor,
                Height = _validHeight,
                HairColor = _validHairColor,
                IssueYear = _validIssueYear,
                PassportId = _validPassportId
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("149cm")]
        [TestCase("194cm")]
        [TestCase("58in")]
        [TestCase("77in")]
        public void Should_ReturnFalse_When_InvalidHeight(string height)
        {
            var sut = new Passport
            {
                BirthYear = _validBirthYear,
                CountryId = "aaa",
                ExpirationYear = _validExpirationYear,
                EyeColor = _validEyeColor,
                Height = height,
                HairColor = _validHairColor,
                IssueYear = _validIssueYear,
                PassportId = _validPassportId
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("aabbcc")]
        [TestCase("#aabbc")]
        [TestCase("#aabbg")]
        public void Should_ReturnFalse_When_InvalidHairColor(string hairColor)
        {
            var sut = new Passport
            {
                BirthYear = _validBirthYear,
                CountryId = "aaa",
                ExpirationYear = _validExpirationYear,
                EyeColor = _validEyeColor,
                Height = _validHeight,
                HairColor = hairColor,
                IssueYear = _validIssueYear,
                PassportId = _validPassportId
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("2009")]
        [TestCase("2021")]
        public void Should_ReturnFalse_When_InvalidIssueYear(string issueYear)
        {
            var sut = new Passport
            {
                BirthYear = _validBirthYear,
                CountryId = "aaa",
                ExpirationYear = _validExpirationYear,
                EyeColor = _validEyeColor,
                Height = _validHeight,
                HairColor = _validHairColor,
                IssueYear = issueYear,
                PassportId = _validPassportId
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("12345678")]
        [TestCase("1234567890")]
        [TestCase("a12345678")]
        public void Should_ReturnFalse_When_InvalidPassportId(string passportId)
        {
            var sut = new Passport
            {
                BirthYear = _validBirthYear,
                CountryId = "aaa",
                ExpirationYear = _validExpirationYear,
                EyeColor = _validEyeColor,
                Height = _validHeight,
                HairColor = _validHairColor,
                IssueYear = _validIssueYear,
                PassportId = passportId
            };
            
            Assert.That(sut.Validate() == false);
        }
        
        [Test]
        [TestCase("1920","a", "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("1920",null, "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("1920",null, "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("2002",null, "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","amb","150cm","#123abc","2020","123456789")]
        [TestCase("1920","a", "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2030","amb","150cm","#123abc","2010","123456789")]
        
        [TestCase("1920","a", "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","amb","193cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","amb","59in","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","amb","76in","#123abc","2010","123456789")]
       
        [TestCase("1920","a", "2020","amb","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","blu","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","brn","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","gry","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","grn","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","hzl","150cm","#123abc","2010","123456789")]
        [TestCase("1920","a", "2020","oth","150cm","#123abc","2010","123456789")]
        
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