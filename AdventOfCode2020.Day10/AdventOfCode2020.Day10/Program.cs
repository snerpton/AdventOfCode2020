using System;
using System.Globalization;
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
            var adapters = FileParser.Parse(fileContentOfAdapterJoltages);

            var joltageAdapterService = new JoltageAdapterService(adapters);
            var numberWith1JoltStep = joltageAdapterService.NumberWithJoltDifferenceOf(1);
            Console.WriteLine($"Number with 1 Jolt difference: {numberWith1JoltStep}");
            
            var numberWith3JoltStep = joltageAdapterService.NumberWithJoltDifferenceOf(3);
            Console.WriteLine($"Number with 1 Jolt difference: {numberWith3JoltStep}");

            Console.WriteLine($"Number of 1-jolt differences multiplied by the number of 3-jolt differences: {numberWith1JoltStep * numberWith3JoltStep}");
        }
    }
}