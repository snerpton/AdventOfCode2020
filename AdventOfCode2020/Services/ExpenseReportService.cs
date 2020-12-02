using System;
using System.Linq;
using AdventOfCode2020.Extensions;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{
    public class ExpenseReportService : IExpenseReportService
    {
        private readonly IExpenseReport _expenseReport;

        public ExpenseReportService(IExpenseReport expenseReport)
        {
            _expenseReport = expenseReport ?? throw new ArgumentNullException(nameof(expenseReport));
        }

        public int Find2NumbersThatAddUpTo2020AndMultiplyTogether()
        {
            const int targetNumberWhenAddedTogether = 2020;

            if (ValidateExpenseReport(_expenseReport) == false)
                throw new InvalidOperationException(
                    "'expense report' has is in an invalid state to make this calculation.");

            var expenseReportEntryCombinations = _expenseReport.Entries.CombinationsOfTwoNumbersWithoutRepetition();

            foreach (var entryCombination in expenseReportEntryCombinations)
                if (entryCombination.Sum() == targetNumberWhenAddedTogether)
                    return entryCombination.Aggregate(1, (current, entry) => current * entry);

            throw new Exception();
        }
        
        public int Find3NumbersThatAddUpTo2020AndMultiplyTogether()
        {
            const int targetNumberWhenAddedTogether = 2020;

            if (ValidateExpenseReport(_expenseReport) == false)
                throw new InvalidOperationException(
                    "'expense report' has is in an invalid state to make this calculation.");

            var expenseReportEntryCombinations = _expenseReport.Entries.CombinationsOfThreeNumbersWithoutRepetition();

            foreach (var entryCombination in expenseReportEntryCombinations)
                if (entryCombination.Sum() == targetNumberWhenAddedTogether)
                    return entryCombination.Aggregate(1, (current, entry) => current * entry);

            throw new Exception();
        }

        private static bool ValidateExpenseReport(IExpenseReport expenseReport)
        {
            if (expenseReport.Entries == null)
                return false;

            if (expenseReport.Entries.Length < 2)
                return false;

            return true;
        }
    }
}