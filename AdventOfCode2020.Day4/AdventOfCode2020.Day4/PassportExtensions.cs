using System;
using System.Linq;

namespace AdventOfCode2020.Day4
{
    public static class PassportExtensions
    {
        public static bool Validate(this Passport passport)
        {
            if (passport == null)
                throw new ArgumentNullException(nameof(passport));
            
            if (ValidateBirthYear(passport.BirthYear) == false)
                return false;

            if (ValidateCountryId(passport.CountryId) == false)
                return false;
            
            if (ValidateExpirationYear(passport.ExpirationYear) == false)
                return false;
            
            if (ValidateEyeColor(passport.EyeColor) == false)
                return false;
            
            if (ValidateHeight(passport.Height) == false)
                return false;
            
            if (ValidateHairColor(passport.HairColor) == false)
                return false;
            
            if (ValidateIssueYear(passport.IssueYear) == false)
                return false;
            
            if (ValidatePassportId(passport.PassportId) == false)
                return false;

            return true;
        }

        private static bool ValidateBirthYear(string passportBirthYear)
        {
            if (string.IsNullOrWhiteSpace(passportBirthYear))
                return false;
            
            if (passportBirthYear.Length != 4)
                return false;
            
            if (int.TryParse(passportBirthYear, out var birthYear) == false)
                return false;

            if (birthYear < 1920 || birthYear > 2002)
                return false;
            
            return true;
        }

        private static bool ValidateCountryId(string passportCountryId)
        {
            //return !string.IsNullOrWhiteSpace(passportCountryId);
            return true; //as optional to allow North Pole Credentials
        }

        private static bool ValidateExpirationYear(string passportExpirationYear)
        {
            if (string.IsNullOrWhiteSpace(passportExpirationYear))
                return false;
            
            if (passportExpirationYear.Length != 4)
                return false;
            
            if (int.TryParse(passportExpirationYear, out var issueYear) == false)
                return false;

            if (issueYear < 2020 || issueYear > 2030)
                return false;
            
            return true;
        }

        private static bool ValidateEyeColor(string passportEyeColor)
        {
            if (string.IsNullOrWhiteSpace(passportEyeColor))
                return false;
            
            var validEyeColour = new [] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            if (validEyeColour.Contains(passportEyeColor) == false)
                return false;

            return true;
        }

        private static bool ValidateHairColor(string passportHairColor)
        {
            if (string.IsNullOrWhiteSpace(passportHairColor))
                return false;

            if (passportHairColor[0] != '#')
                return false;

            passportHairColor = passportHairColor.Replace("#", "");
            if (passportHairColor.Length != 6)
                return false;
            
            var validChars = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
            foreach (var character in passportHairColor)
            {
                if (validChars.Contains(character) == false)
                    return false;
            }

            return true;
        }    
        
        private static bool ValidateHeight(string height)
        {
            if (string.IsNullOrWhiteSpace(height))
                return false;

            if (height.Contains("cm"))
            {
                var heightNum = int.Parse(height.Replace("cm", ""));
                if (heightNum < 150 || heightNum > 193)
                    return false;
            }
            else if (height.Contains("in"))
            {
                var heightNum = int.Parse(height.Replace("in", ""));
                if (heightNum < 59 || heightNum > 76)
                    return false;
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool ValidateIssueYear(string passportIssueYear)
        {
            if (string.IsNullOrWhiteSpace(passportIssueYear))
                return false;
            
            if (passportIssueYear.Length != 4)
                return false;
            
            if (int.TryParse(passportIssueYear, out var issueYear) == false)
                return false;

            if (issueYear < 2010 || issueYear > 2020)
                return false;
            
            return true;
        }

        private static bool ValidatePassportId(string passportPassportId)
        {
            if (string.IsNullOrWhiteSpace(passportPassportId))
                return false;

            if (passportPassportId.Length != 9)
                return false;

            var validChars = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            foreach (var character in passportPassportId)
            {
                if (validChars.Contains(character) == false)
                    return false;
            }
            
            return true;
        }
    }
}