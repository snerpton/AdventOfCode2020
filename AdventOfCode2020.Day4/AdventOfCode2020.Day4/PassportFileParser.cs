using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode2020.Day4
{
    public static class PassportFileParser
    {
        private static readonly string _passportFileAndPath = 
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "/Assets/Day3PuzzleInputPassports.txt";
        
        public static string[] Parse()
        {
            var fileContent = File.ReadAllText(_passportFileAndPath);
            var passports = fileContent.Split(new string[] {"\r\n\r\n", "\n\n", "\r\r"}, StringSplitOptions.RemoveEmptyEntries);

            return passports;
        }
    }
}