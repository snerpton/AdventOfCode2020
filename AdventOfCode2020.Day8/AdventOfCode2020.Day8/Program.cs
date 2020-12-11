using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Day8
{
    class Program
    {
        private static string instructionsFileAndPath =
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "/Assets/Day8PuzzleInputInstructions.txt";

        static void Main(string[] args)
        {
            var fileContents = FileParser.Read(instructionsFileAndPath);
            var instructions = FileParser.Parse(fileContents);

            var bootConsole = new BootConsole(instructions.ToArray());
            bootConsole.Run();

            Console.WriteLine($"Accumulator value: {bootConsole.Accumulator}");
            Console.WriteLine($"LineNumber value: {bootConsole.LineNumber}");
        }
    }
}