using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code 2020, Day 5!");
            
            var boardingPassFileAndPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
                               "/Assets/Day5PuzzleInputBoardingPass.txt";

            var boardingPassRows = File.ReadLines(boardingPassFileAndPath);
            var boardingPass = boardingPassRows.Select(r => new BoardingPass(r));
            
            Console.WriteLine($"Number of entries in Boarding Pass input file: {boardingPassRows.Count()}");
            Console.WriteLine($"Number of valid Boarding Pass: {boardingPass.Count(x => x.IsValid())}");

            var highestSeatId = boardingPass.Max(x => x.SeatId());
            
            Console.WriteLine($"Highest  Seat ID: {highestSeatId}");
        }
    }
}