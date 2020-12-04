using System;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{
    public class DailyPuzzleService
    {
        private readonly IExpenseReportService _expenseReportService;
        private readonly IPasswordReportService _passwordReportService;
        private readonly IXmasTreeMapService _xmasTreeMapService;

        public DailyPuzzleService(IExpenseReportService expenseReportService, IPasswordReportService passwordReportService, IXmasTreeMapService xmasTreeMapService)
        {
            _expenseReportService =
                expenseReportService ?? throw new ArgumentNullException(nameof(expenseReportService));

            _passwordReportService =
                passwordReportService ?? throw new ArgumentNullException(nameof(passwordReportService));

            _xmasTreeMapService = 
                xmasTreeMapService ?? throw new ArgumentNullException(nameof(xmasTreeMapService));
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
                case AdventDayNumber.Day03:
                    DoDay3();
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
        
        private void DoDay3()
        {
            Console.WriteLine("Part 1...");
            var numberOfTreesEncountered = _xmasTreeMapService.CountTrees(3,1);
            Console.WriteLine($"Number of trees encountered for right 3, down 1: {numberOfTreesEncountered}");
            Console.WriteLine();

            Console.WriteLine("Part 2...");
            var runningMultiplyTotal = 1;
            var right = 1;
            var down = 1;
            numberOfTreesEncountered = _xmasTreeMapService.CountTrees(right,down);
            Console.WriteLine($"Number of trees encountered for right {right}, down {down}: {numberOfTreesEncountered}");
            runningMultiplyTotal = runningMultiplyTotal * numberOfTreesEncountered;
            
            right = 3; 
            down = 1;
            numberOfTreesEncountered = _xmasTreeMapService.CountTrees(right,down);
            Console.WriteLine($"Number of trees encountered for right {right}, down {down}: {numberOfTreesEncountered}");
            runningMultiplyTotal = runningMultiplyTotal * numberOfTreesEncountered;
            
            right = 5; 
            down = 1;
            numberOfTreesEncountered = _xmasTreeMapService.CountTrees(right,down);
            Console.WriteLine($"Number of trees encountered for right {right}, down {down}: {numberOfTreesEncountered}");
            runningMultiplyTotal = runningMultiplyTotal * numberOfTreesEncountered;
            
            right = 7; 
            down = 1;
            numberOfTreesEncountered = _xmasTreeMapService.CountTrees(right,down);
            Console.WriteLine($"Number of trees encountered for right {right}, down {down}: {numberOfTreesEncountered}");
            runningMultiplyTotal = runningMultiplyTotal * numberOfTreesEncountered;
            
            right = 1; 
            down = 2;
            numberOfTreesEncountered = _xmasTreeMapService.CountTrees(right,down);
            Console.WriteLine($"Number of trees encountered for right {right}, down {down}: {numberOfTreesEncountered}");
            runningMultiplyTotal = runningMultiplyTotal * numberOfTreesEncountered;

            Console.WriteLine($"Totals multiplied together: {runningMultiplyTotal}");
        }
    }
}