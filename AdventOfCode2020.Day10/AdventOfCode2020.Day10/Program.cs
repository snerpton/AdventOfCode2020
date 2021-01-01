using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode2020.Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code Day 10!");

            var filePathAndName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                  "/Assets/Day10PuzzleInputOutputJoltage.txt";

            var fileContentOfAdapterJoltages = FileParser.Read(filePathAndName);

        }
    }
}