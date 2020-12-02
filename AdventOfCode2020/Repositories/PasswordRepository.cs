using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
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

        protected PasswordEntry PasswordEntryFromFileLine(string line)
        {
            var password = PasswordFromLine(line);
            var policyletter = PolicyLetterFromLine(line);
            var policyMax = PolicyMaxFromLine(line);
            var policyMin = PolicyMinFromLine(line);
            var passwordPolicy = new PasswordPolicy { Letter = policyletter, RangeMax = policyMax, RangeMin = policyMin};
            return new PasswordEntry {Password = password, PwPolicy = passwordPolicy};
        }

        private string PasswordFromLine(string line) => line.Split(new[] {':'})[1].Trim();

        private char PolicyLetterFromLine(string line) => line.Split(new[] {'-', ' ', ':'})[2].First();
        
        private int PolicyMinFromLine(string line) => int.Parse(line.Split(new[] {'-'})[0]);

        private int PolicyMaxFromLine(string line) => int.Parse(line.Split(new[] {'-', ' '})[1]);
        
    }
}