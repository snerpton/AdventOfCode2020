using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCode2020.Day9.Models;

namespace AdventOfCode2020.Day9
{
    public static class FileParser
    {
        private static readonly char[] _validStateCharacters = {'.', '#'};
        private static readonly string FilePath =
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "/Assets/Day9PuzzleInputInitialCubeState.txt";

        public static IEnumerable<string> Read()
        {
            return File.ReadLines(FilePath);
        }

        public static IEnumerable<GridPoint> ParseXRow(string xRow, int y, int z)
        {
            if (xRow == null)
                throw new ArgumentNullException(nameof(xRow));

            if (xRow == "")
                throw new ArgumentOutOfRangeException(nameof(xRow));

            if (xRow.Any(c => _validStateCharacters.Contains(c) == false))
                throw new ArgumentOutOfRangeException(nameof(xRow));

            if (y < 0)
                throw new ArgumentOutOfRangeException(nameof(y));
            
            if (z < 0)
                throw new ArgumentOutOfRangeException(nameof(y));
            
            return xRow.Select((c, index) => ParseToGridPoint(c, index, y, z));
        }

        private static GridPoint ParseToGridPoint(char c, int x, int y, int z) => 
            new GridPoint {State = ParseCharacterToState(c), X = x, Y = y, Z = z};

        private static State ParseCharacterToState(char character)
        {
            switch (character)
            {
                case '#':
                    return State.Active;
                case '.':
                    return State.Inactive;
                default:
                    throw new ArgumentOutOfRangeException(nameof(character));
            }
        }
    }
}