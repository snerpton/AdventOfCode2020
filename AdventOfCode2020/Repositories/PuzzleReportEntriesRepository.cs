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
            "/Assets/PuzzleReportEntries.txt";

        public IEnumerable<int> ReadFile()
        {
            var lines = File.ReadLines(PuzzleReportPathAndFileName);

            return lines.Select(int.Parse);
        }
    }
}