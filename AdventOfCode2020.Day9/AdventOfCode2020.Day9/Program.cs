using System;
using System.Linq;

namespace AdventOfCode2020.Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Day 9...");

            var fileLines = FileParser.Read();
            var gridPoints = fileLines.SelectMany((line, yIndex) => FileParser.ParseXRow(line, yIndex, 0, 0));

            const int numberOfIterations = 6;
            var initialProblemGrid = gridPoints.ToProblemGridFromGridPoints(numberOfIterations);
            var numberInActiveStateAfterIterations = initialProblemGrid.CalculateNumberOfActiveStateCubesAfterIterating(numberOfIterations);

            Console.WriteLine($"Number in active state after {numberOfIterations}: {numberInActiveStateAfterIterations}");
        }
    }
}