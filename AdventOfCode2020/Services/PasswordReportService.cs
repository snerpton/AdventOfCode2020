using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Extensions;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{
    public class PasswordReportService : IPasswordReportService
    {
        private readonly IEnumerable<PasswordEntry> _passwordEntries;

        public PasswordReportService()
        {
        }
        
        public PasswordReportService(IEnumerable<PasswordEntry> passwordEntries)
        {
            _passwordEntries = passwordEntries ?? throw new ArgumentNullException(nameof(passwordEntries));
        }
        
        public int NumberOfValidPasswords() => _passwordEntries.Count(x => ValidatePassword(x) == true);

        public bool ValidatePassword(PasswordEntry passwordEntry)
        {
            // Validate policy
            if (passwordEntry.PwPolicy.RangeMin < 0)
                return false;

            if (passwordEntry.PwPolicy.RangeMax < 0)
                return false;

            if (passwordEntry.PwPolicy.RangeMax < passwordEntry.PwPolicy.RangeMin) 
                return false;

            var occurenceOfLetterInPassword = passwordEntry.Password.Occurence(passwordEntry.PwPolicy.Letter);

            if (occurenceOfLetterInPassword < passwordEntry.PwPolicy.RangeMin ||
                occurenceOfLetterInPassword > passwordEntry.PwPolicy.RangeMax)
                return false;
            
            return true;
        }
    }
}