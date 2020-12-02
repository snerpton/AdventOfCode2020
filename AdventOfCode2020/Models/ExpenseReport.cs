using System;
using System.Linq;
using AdventOfCode2020.Repositories;

namespace AdventOfCode2020.Models
{
    public class ExpenseReport : IExpenseReport
    {
        public ExpenseReport()
        {
        }

        public ExpenseReport(IPuzzleReportEntriesRepository puzzleReportEntriesRepository)
        {
            if (puzzleReportEntriesRepository == null)
                throw new ArgumentNullException(nameof(puzzleReportEntriesRepository));

            Entries = puzzleReportEntriesRepository.ReadFile().ToArray();
        }

        public int[] Entries { get; set; }
    }
}