using System.Collections.Generic;

namespace AdventOfCode2020.Repositories
{
    public interface IPuzzleReportEntriesRepository
    {
        IEnumerable<int> ReadFile();
    }
}