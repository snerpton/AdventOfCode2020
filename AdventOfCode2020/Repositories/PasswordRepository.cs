using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private static readonly string PasswordListPathAndFileName =
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "/Assets/Day2PuzzleInputPasswordList.txt";

        public IEnumerable<PasswordEntry> ReadFile()
        {
            var lines = File.ReadLines(PasswordListPathAndFileName);

            return lines.Select(line => PasswordEntryFromFileLine(line));
        }

        private PasswordEntry PasswordEntryFromFileLine(string line)
        {
            var lineParts = line.Split(new[] {':'});
            var password = lineParts[1].Trim();
            var policyMax = int.Parse(lineParts[0].Trim().Split(new[] {'-'}).ElementAt(1));
            var policyMin = int.Parse(lineParts[0].Trim().Split(new[] {'-'}).ElementAt(0));
            var passwordPolicy = new PasswordPolicy {RangeMax = policyMax, RangeMin = policyMin};
            return new PasswordEntry {Password = password, PwPolicy = passwordPolicy};
        }
    }
}