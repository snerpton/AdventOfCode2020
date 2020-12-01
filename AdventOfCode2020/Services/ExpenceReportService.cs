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
        }


        public int Find2NumbersThatAddUpTo2020AndMultiplyTogether()
        {
            throw new NotImplementedException();
        }
    }
}
