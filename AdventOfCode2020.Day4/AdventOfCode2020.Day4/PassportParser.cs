using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day4
{
    public static class PassportParser
    {   
        public static Passport Parse(string passportString)
        {
            if (string.IsNullOrWhiteSpace(passportString))
                throw new ArgumentOutOfRangeException(nameof(passportString));

            var passportStringLines = passportString.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
            if (passportStringLines.Any(line => string.IsNullOrWhiteSpace(line)))
                throw new ArgumentOutOfRangeException(nameof(passportString));


            var passportKeyValues =
                passportString.Split(new[] {" ", "\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            
            if (passportKeyValues.Any(keyValue => ValidateKeyValue(keyValue) == false))
                throw new ArgumentOutOfRangeException(nameof(passportString));
           

            var passport = new Passport();
            foreach (var keyValue in passportKeyValues)
                MapKeyValue(keyValue, ref passport);

            return passport;
        }

        private static bool ValidateKeyValue(string keyValue)
        {
            if (keyValue.Contains(":") == false)
                return false;

            try
            {
                var passport = new Passport();
                MapKeyValue(keyValue, ref passport);
            }
            catch (Exception e)
            {
                return false;
            }
            
            return true;
        }
        
        private static string KeyFromKeyValue(string keyValue) =>
            keyValue.Split(new string[] {":"}, StringSplitOptions.None)[0];

        private static string ValueFromKeyValue(string keyValue) =>
            keyValue.Split(new string[] {":"}, StringSplitOptions.None)[1];
        
        private static void MapKeyValue(string keyValue, ref Passport passport)
        {
            var key = KeyFromKeyValue(keyValue);
            var value = ValueFromKeyValue(keyValue);
            switch (key)
            {
                case "byr":
                    passport.BirthYear = value;
                    break;
                case "iyr":
                    passport.IssueYear = value;
                    break;
                case "eyr":
                    passport.ExpirationYear = value;
                    break;
                case "hgt":
                    passport.Height = value;
                    break;
                case "hcl":
                    passport.HairColor = value;
                    break;
                case "ecl":
                    passport.EyeColor = value;
                    break;
                case "pid":
                    passport.PassportId = value;
                    break;
                case "cid":
                    passport.CountryId = value;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}