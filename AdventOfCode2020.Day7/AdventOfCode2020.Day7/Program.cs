using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode2020.Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code 2020, Day 7!");

            var aviationRegulationsFileAndPath =
                Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
                "/Assets/Day7PuzzleInputAviationRegulations.txt";

            var aviationRegulationsFileContent = File.ReadLines(aviationRegulationsFileAndPath);

            var a = 1;

        }
    }
}