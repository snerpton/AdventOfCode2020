using AdventOfCode2020.Models;
using AdventOfCode2020.Repositories;
using AdventOfCode2020.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2020
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        private const AdventDayNumber DayNumber = Models.AdventDayNumber.Day02;

        static void Main(string[] args)
        {
            // DI / register services
            var serviceCollection = new ServiceCollection();
            RegisterServices(serviceCollection);

            // Solve Advent of Code daily puzzle
            var expenseReportService = _serviceProvider.GetService<IExpenseReportService>();
            var dailyPuzzleService = new DailyPuzzleService(expenseReportService);
            dailyPuzzleService.DoDailyPuzzle(DayNumber);
        }

        private static void RegisterServices(IServiceCollection serviceProvider)
        {
            _serviceProvider = serviceProvider
                .AddSingleton<IPuzzleReportEntriesRepository, PuzzleReportEntriesRepository>()
                .AddSingleton<IExpenseReport, ExpenseReport>(s =>
                    new ExpenseReport(s.GetService<IPuzzleReportEntriesRepository>()))
                .AddSingleton<IExpenseReportService, ExpenseReportService>()
                .BuildServiceProvider();
        }
    }
}
