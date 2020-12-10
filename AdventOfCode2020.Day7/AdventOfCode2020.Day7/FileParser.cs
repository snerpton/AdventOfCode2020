using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Day7
{
    public static class FileParser
    {
        private static string aviationRegulationsFileAndPath =
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "/Assets/Day7PuzzleInputAviationRegulations.txt";
        
        public static BagTypeRule[] Parse()
        {
            var aviationRegulationsFileContent = File.ReadLines(aviationRegulationsFileAndPath);

            return aviationRegulationsFileContent.Select(line => ParseLineToRule(line)).ToArray();
        }
        
        public static BagTypeRule ParseLineToRule(string line)
        {
            var colour = line.Split(new string[] {" bags contain"}, StringSplitOptions.None)[0];
            
            var childBagsFragment = line.Split(new string[] {" bags contain"}, StringSplitOptions.None)[1];
            var childBags = new List<ChildBagRule>();
            if (childBagsFragment.Contains("no other") == false)
            {
                childBags = ParseChildBagsFragment(childBagsFragment).ToList();
            }

            return new BagTypeRule
            {
                Colour = colour,
                ChildBags = childBags.ToArray()
            };
        }

        private static IEnumerable<ChildBagRule> ParseChildBagsFragment(string fragment)
        {
            fragment = fragment
                .Replace("bags", "")
                .Replace("bag", "")
                .Replace(".", "")
                .Trim();

            var childBagParts = fragment.Split(new[] {","}, StringSplitOptions.TrimEntries);

            foreach (var childBagPart in childBagParts)
            {
                var number = childBagPart.Split(new[] {" "}, StringSplitOptions.None)[0];
                var bag = childBagPart.Replace(number, "").Trim();
                yield return new ChildBagRule
                {
                    Bag = bag,
                    Number = int.Parse(number)
                };
            }
        }
    }
}