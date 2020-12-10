using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            var matchingBags = bagService.FindNumberOfBagsThatEventuallyContain(1, bagColour);

            Console.WriteLine($"Number of bags that eventually contain '{bagColour}': {matchingBags}");

        }
    }
}