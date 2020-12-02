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
                //.AddLogging(logging => logging.AddConsole())
                .AddSingleton<IPuzzleReportEntriesRepository, PuzzleReportEntriesRepository>()
                .AddSingleton<IExpenseReport, ExpenseReport>(s => new ExpenseReport(s.GetService<IPuzzleReportEntriesRepository>()))
                .AddSingleton<IExpenseReportService, ExpenseReportService>()
                .BuildServiceProvider();
            
            var expenseReportService = serviceProvider.GetService<IExpenseReportService>();
            var twoNumbersMultiplied = expenseReportService.Find2NumbersThatAddUpTo2020AndMultiplyTogether();
            
            Console.WriteLine($"Multiple of two numbers that when summed equal 2020, but when multiplied = {twoNumbersMultiplied}"); 
        }
    }
}
