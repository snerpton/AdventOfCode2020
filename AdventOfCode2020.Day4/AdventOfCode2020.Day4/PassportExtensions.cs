using System;
using System.ComponentModel.DataAnnotations;

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

        private static bool ValidateExpirationYear(string passportExpirationYear) => !string.IsNullOrWhiteSpace(passportExpirationYear);
        
        private static bool ValidateEyeColor(string passportEyeColor) => !string.IsNullOrWhiteSpace(passportEyeColor);
        
        private static bool ValidateHeight(string height) => !string.IsNullOrWhiteSpace(height);

        private static bool ValidateHairColor(string passportHairColor) => !string.IsNullOrWhiteSpace(passportHairColor);
        
        private static bool ValidateIssueYear(string passportIssueYear) => !string.IsNullOrWhiteSpace(passportIssueYear);
        
        private static bool ValidatePassportId(string passportPassportId) => !string.IsNullOrWhiteSpace(passportPassportId);
    }
}