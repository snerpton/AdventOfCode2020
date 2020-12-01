using System;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{

    public class ExpenceReportService
    {
        private readonly ExpenseReport _expenceReport;

        public ExpenceReportService(ExpenseReport expenceReport)
        {
            _expenceReport = expenceReport ?? throw new ArgumentNullException(nameof(expenceReport));

            if (ValidateExpenceReport(_expenceReport) == false)
                throw new ArgumentException(nameof(expenceReport));
        }

        public int Find2NumbersThatAddUpTo2020AndMultiplyTogether()
        {
            throw new NotImplementedException();
        }

        private static bool ValidateExpenceReport(ExpenseReport expenceReport)
        {
            if (expenceReport.Entries == null)
                return false;

            if (expenceReport.Entries.Length < 2)
                return false;

            return true;
        }
    }
}
