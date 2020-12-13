using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCode2020.Day8.Models;

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
            
            // Part 2...
            System.Console.WriteLine();
            System.Console.WriteLine("Part 2...");
            System.Console.WriteLine($"Number of instruction lines: {instructions.Count()}");
            for(var index=0; index < instructions.ToArray().Count(); index++)
            {
                var updatedInstructions = instructions.ToArray();
                updatedInstructions[index].Operation = UpdateInstruction(updatedInstructions[index].Operation);
                var bootConsole2 = new BootConsole(updatedInstructions);
                bootConsole2.Run();
                if (bootConsole2.LineNumber == instructions.Count())
                {
                    Console.WriteLine($"Accumulator value: {bootConsole2.Accumulator}");
                    Console.WriteLine($"LineNumber value: {bootConsole2.LineNumber}");
                }
            }
        }

        private static Operation UpdateInstruction(Operation origOperation)
        {
            Operation operation = origOperation switch
            {
                Operation.ACC => Operation.ACC,
                Operation.JMP => Operation.NOP,
                Operation.NOP => Operation.JMP

            };
            return operation;
        }
    }
}