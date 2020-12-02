using System;
using System.Collections;
using System.Linq;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{

    public class ExpenseReportService
    {
        private readonly ExpenseReport _expenseReport;

        public ExpenseReportService(ExpenseReport expenseReport)
        {
            _expenseReport = expenseReport ?? throw new ArgumentNullException(nameof(expenseReport));
        }

        public int Find2NumbersThatAddUpTo2020AndMultiplyTogether()
        {
            var targetNumberWhenAddedTogether = 2020;

            if (ValidateExpenseReport(_expenseReport) == false)
                throw new InvalidOperationException("'expense report' has is in an invalid state to make this calculation.");

            var expenseReportEntryCombinations = _expenseReport.Entries.CombinationsOfTwoNumbersWithoutRepetition();
            
            foreach (var entryCombination in expenseReportEntryCombinations)
            {
                if (entryCombination.Sum() == targetNumberWhenAddedTogether)
                {
                    var runningTotal = 1;
                    foreach (var entry in entryCombination)
                        runningTotal *= entry;

                    return runningTotal;
                }
            }
            
            throw new Exception();
        }

        private static bool ValidateExpenseReport(ExpenseReport expenseReport)
        {
            if (expenseReport.Entries == null)
                return false;

            if (expenseReport.Entries.Length < 2)
                return false;

            return true;
        }
    }
}
