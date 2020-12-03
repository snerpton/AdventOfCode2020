using System;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{
    public class DailyPuzzleService
    {
        private readonly IExpenseReportService _expenseReportService;
        private readonly IPasswordReportService _passwordReportService;

        public DailyPuzzleService(IExpenseReportService expenseReportService, IPasswordReportService passwordReportService)
        {
            _expenseReportService =
                expenseReportService ?? throw new ArgumentNullException(nameof(expenseReportService));

            _passwordReportService =
                passwordReportService ?? throw new ArgumentNullException(nameof(passwordReportService));
        }
        
        public void DoDailyPuzzle(AdventDayNumber dayNumber)
        {
            switch (dayNumber)
            {
                case AdventDayNumber.Day01:
                    DoDay1();
                    break;
                case AdventDayNumber.Day02:
                    DoDay2();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }   
        }

        private void DoDay1()
        {
            var twoNumbersMultiplied = _expenseReportService.Find2NumbersThatAddUpTo2020AndMultiplyTogether();
            Console.WriteLine($"Day 1 part 1: sum two numbers equal to 2020, and when multiplied = {twoNumbersMultiplied}");

            var threeNumbersMultiplied = _expenseReportService.Find3NumbersThatAddUpTo2020AndMultiplyTogether();
            Console.WriteLine($"Day 1 part 2: sum three numbers equal to 2020, and when multiplied = {threeNumbersMultiplied}");
        }
        
        private void DoDay2()
        {
            var numberOfInvalidPassword = _passwordReportService.NumberOfValidPasswords();
            Console.WriteLine($"Number of valid password: {numberOfInvalidPassword}");
        }
    }
}