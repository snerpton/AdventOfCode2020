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
            var passwordReportService = _serviceProvider.GetService<IPasswordReportService>();
            var dailyPuzzleService = new DailyPuzzleService(expenseReportService, passwordReportService);
            dailyPuzzleService.DoDailyPuzzle(DayNumber);
        }

        private static void RegisterServices(IServiceCollection serviceProvider)
        {
            _serviceProvider = serviceProvider
                // Day 1    
                .AddSingleton<IPuzzleReportEntriesRepository, PuzzleReportEntriesRepository>()
                .AddSingleton<IExpenseReport, ExpenseReport>(s =>
                    new ExpenseReport(s.GetService<IPuzzleReportEntriesRepository>()))
                .AddSingleton<IExpenseReportService, ExpenseReportService>()
                
                // Day 2
                .AddSingleton<IPasswordRepository, PasswordRepository>()
                .AddSingleton<IPasswordReportService, PasswordReportService>(s => new PasswordReportService(s
                    .GetService<IPasswordRepository>()
                    .ReadFile()))
                .BuildServiceProvider();
        }
    }
}
