using System;
using System.Linq;

namespace AdventOfCode2020.Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code 2020, Day 7!");

            var bagRules = FileParser.Parse();
            var bagService = new BagService(bagRules.ToArray());
            
            var bagColour = "shiny gold";
            var matchingBags = bagService.FindNumberOfBagsThatEventuallyContain(bagColour);

            Console.WriteLine($"Number of bags that eventually contain '{bagColour}': {matchingBags}");

        }
    }
}