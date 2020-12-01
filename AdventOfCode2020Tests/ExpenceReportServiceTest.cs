using NUnit.Framework;
using AdventOfCode2020.Services;
using System;

namespace AdventOfCode2020Tests
{
    public class ExpenceReportServiceTest
    {
        [Test]
        public void Should_ThrowException_When_NullExpenseReport()
        {
            Assert.Throws<ArgumentNullException>(() => new ExpenceReportService(null));
        }
    }
}