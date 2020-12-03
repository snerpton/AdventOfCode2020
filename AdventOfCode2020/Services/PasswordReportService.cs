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
            if (passwordEntry.PwPolicy.Position1 < 0)
                return false;

            if (passwordEntry.PwPolicy.Position2 < 0)
                return false;

            if (ValidatePassWordAgainstPolicy(passwordEntry) == false)
                return false;
            
            return true;
        }

        private bool ValidatePassWordAgainstPolicy(PasswordEntry passwordEntry)
        {
            return
                CharacterInPosition(passwordEntry.Password,
                    passwordEntry.PwPolicy.Letter,
                    passwordEntry.PwPolicy.Position1) ^
                CharacterInPosition(passwordEntry.Password,
                    passwordEntry.PwPolicy.Letter,
                    passwordEntry.PwPolicy.Position2);
        }
        
        private bool CharacterInPosition(string haystack, char needle, int position)
        {
            return haystack.Substring(position - 1,1) == needle.ToString();
        }
    }
}