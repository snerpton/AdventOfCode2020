using System;
using AdventOfCode2020.Models;
using AdventOfCode2020.Repositories;
using AdventOfCode2020.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPuzzleReportEntriesRepository, PuzzleReportEntriesRepository>()
                .AddSingleton<IExpenseReport, ExpenseReport>(s => new ExpenseReport(s.GetService<IPuzzleReportEntriesRepository>()))
                .AddSingleton<IExpenseReportService, ExpenseReportService>()
                .BuildServiceProvider();
            
            var expenseReportService = serviceProvider.GetService<IExpenseReportService>();
            var twoNumbersMultiplied = expenseReportService.Find2NumbersThatAddUpTo2020AndMultiplyTogether();
            Console.WriteLine($"Day 1 part 1: sum two numbers equal to 2020, and when multiplied = {twoNumbersMultiplied}"); 
            
            var threeNumbersMultiplied = expenseReportService.Find3NumbersThatAddUpTo2020AndMultiplyTogether();
            Console.WriteLine($"Day 1 part 2: sum three numbers equal to 2020, and when multiplied = {threeNumbersMultiplied}");  
        }
    }
}
