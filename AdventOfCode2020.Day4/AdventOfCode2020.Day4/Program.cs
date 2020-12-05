using System;
using System.Linq;

namespace AdventOfCode2020.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Day 4!");

            var rawPassports = PassportFileParser.Parse();
            var passports = PassportParser.Parse(rawPassports);
            var validPassports = passports.Where(p => p.Validate());
            
            Console.WriteLine($"Number of raw passports (including North Pole Credentials is: {rawPassports.Count()}");
            Console.WriteLine($"Number of passports (including North Pole Credentials is: {passports.Count()}");
            Console.WriteLine($"Number of valid passports (including North Pole Credentials is: {validPassports.Count()}");
        }
    }
}