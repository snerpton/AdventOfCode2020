using System;
using AdventOfCode2020.Repositories;
using AdventOfCode2020.Services;
using Moq;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    public class DailyPuzzleServiceTests
    {
        [Test]
        public void Should_ThrowException_When_ExpenseReportServiceIsNull()
        {
            var mockPasswordReportService = new Mock<IPasswordReportService>();
            Assert.Throws<ArgumentNullException>(() => new DailyPuzzleService(null, mockPasswordReportService.Object));
        }
        
        [Test]
        public void Should_ThrowException_When_PasswordReportServiceIsNull()
        {
            var mockExpenseReportService = new Mock<IExpenseReportService>();
            Assert.Throws<ArgumentNullException>(() => new DailyPuzzleService(mockExpenseReportService.Object, null));
        }
    }
}