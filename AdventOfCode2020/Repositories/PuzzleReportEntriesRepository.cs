using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Repositories
{
    public class PuzzleReportEntriesRepository : IPuzzleReportEntriesRepository
    {
        private static readonly string PuzzleReportPathAndFileName =
            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
            "/Assets/Day1PuzzleInputReportEntries.txt";

        public IEnumerable<int> ReadFile()
        {
            var lines = File.ReadLines(PuzzleReportPathAndFileName);

            return lines.Select(int.Parse);
        }
    }
    
    public interface IXmasTreeMapRepository
    {
        IEnumerable<MapLocation> ReadFile();
    }

    public enum PositionType
    {
        Open,
        Tree
    }
    public class MapLocation
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public PositionType Type { get; set; }
    }

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
            throw new NotImplementedException();
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