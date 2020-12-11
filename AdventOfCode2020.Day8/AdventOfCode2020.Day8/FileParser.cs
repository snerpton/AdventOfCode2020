using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode2020.Day8
{
    public static class FileParser
    {
        private static string instructionsFileAndPath =
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "/Assets/Day8PuzzleInputInstructions.txt";
        
        public static void Parse()
        {
            var instructions = File.ReadLines(instructionsFileAndPath);
            
            return;
        }
    }
}