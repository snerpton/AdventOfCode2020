using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Repositories
{
    public class XmasTreeMapRepository : IXmasTreeMapRepository
    {
        private static readonly string PuzzleReportPathAndFileName =
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "Day3PuzzleInputMapOfTrees.txt";

        public IEnumerable<MapLocation> ReadFile()
        {
            var lines = File.ReadLines(PuzzleReportPathAndFileName);
            
            throw new NotImplementedException();
        }

        protected IEnumerable<MapLocation> MapLocationsFromLines(string[] lines)
        {
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            
            if (lines.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(lines));

            var locationMap = new List<MapLocation>();
            for (var y = 0; y < lines.Length; y++)
                locationMap.AddRange(MapLocationsFromLine(lines[y], y));

            return locationMap;
        }
        
        protected IEnumerable<MapLocation> MapLocationsFromLine(string line, int yPosition)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));
            
            if (ValidateLine(line) == false)
                throw new ArgumentOutOfRangeException(nameof(line));

            return line.Select((character, xIndex) => new MapLocation
                {Type = TypeFromCharacter(character), XPosition = xIndex, YPosition = yPosition}).ToList();
        }

        private static bool ValidateLine(string line) =>
            line.All(character => character == '.' || character == '#');

        private PositionType TypeFromCharacter(char character)
        {
            return character switch
            {
                '.' => PositionType.Open,
                '#' => PositionType.Tree
            };
        }
    }
}