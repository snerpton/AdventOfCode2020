using NUnit.Framework;
using AdventOfCode2020.Services;
using System;
using AdventOfCode2020.Models;

namespace AdventOfCode2020Tests
{
    public class ExpenceReportServiceTest
    {
        //private int[] exampleExpenseReportEntries = new int[] { 1721, 979, 366, 299, 675, 1456 };

        [Test]
        public void Should_ThrowException_When_NullExpenseReport()
        {
            Assert.Throws<ArgumentNullException>(() => new ExpenceReportService(null));
        }

        [Test]
        public void Should_ThrowException_When_ExpenceReportEntriesAreNull()
        {
            var mockExpenceReport = new ExpenseReport() { Entries = null };

            Assert.Throws<ArgumentException>(() => new ExpenceReportService(mockExpenceReport));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        public void Should_ThrowException_When_ExpenceReportNumberOfEntriesIsEmptyOrLessThan2(int[] expenceEntries)
        {
            var mockExpenceReport = new ExpenseReport() { Entries = expenceEntries };

            Assert.Throws<ArgumentException>(() => new ExpenceReportService(mockExpenceReport));
        }
    }
}