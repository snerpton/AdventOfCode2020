using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day9
{
    public static class FileParser
    {
        public static IEnumerable<string> Read(string filePathAndName)
        {
            if (filePathAndName == null) 
                throw new ArgumentNullException(nameof(filePathAndName));
            
            if (string.IsNullOrWhiteSpace(filePathAndName))
                throw new ArgumentOutOfRangeException(nameof(filePathAndName));

            return File.ReadLines(filePathAndName);
        }

        public static IEnumerable<int> Parse(IEnumerable<string> inputLines)
        {
            if (inputLines == null) 
                throw new ArgumentNullException(nameof(inputLines));
            
            if (inputLines.Any() == false)
                throw new ArgumentOutOfRangeException(nameof(inputLines));

            return inputLines.Select(line => int.Parse(line));
        }
    }
}