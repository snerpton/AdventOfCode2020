using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Day9
{
    class Program
    {
        private static string _inputPathAndFile =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Assets/Day9PuzzleInput.txt"; 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Day 9...");

            var fileLines = FileParser.Read(_inputPathAndFile);
            var inputCodeLines = FileParser.Parse(fileLines);
  
            var xmasCypherHelper = new XmasCypherHelpers(inputCodeLines);

            var preambleCount = 25;
            if (xmasCypherHelper.Validate(preambleCount, out var firstInvalidNumber) == true)
                Console.WriteLine("Something went wrong as there is valid input!");

            Console.WriteLine($"First invalid number is: {firstInvalidNumber}");
        }
    }
}