using System;
using System.Collections.Generic;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{
    public class PasswordReportService : IPasswordReportService
    {
        private readonly IEnumerable<PasswordEntry> _passwordEntries;
        public PasswordReportService(IEnumerable<PasswordEntry> passwordEntries)
        {
            _passwordEntries = passwordEntries ?? throw new ArgumentNullException(nameof(passwordEntries));
        }
        
        public int NumberOfInvalidPasswords()
        {
            throw new NotImplementedException();
        }
    }
}