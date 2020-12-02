using System;
using AdventOfCode2020.Models;
using AdventOfCode2020.Services;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    public class ExpenceReportServiceTest
    {
        //private int[] exampleExpenseReportEntries = new int[] { 1721, 979, 366, 299, 675, 1456 };

        [Test]
        public void Should_ThrowException_When_NullExpenseReport()
        {
            Assert.Throws<ArgumentNullException>(() => new ExpenseReportService(null));
        }

        [Test]
        public void Should_ThrowException_When_ExpenseReportEntriesAreNull()
        {
            var mockExpenceReport = new ExpenseReport {Entries = null};
            var sut = new ExpenseReportService(mockExpenceReport);

            Assert.Throws<InvalidOperationException>(() => sut.Find2NumbersThatAddUpTo2020AndMultiplyTogether());
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new[] {1})]
        public void Should_ThrowException_When_ExpenseReportNumberOfEntriesIsEmptyOrLessThan2(int[] expenseEntries)
        {
            var mockExpenceReport = new ExpenseReport {Entries = expenseEntries};
            var sut = new ExpenseReportService(mockExpenceReport);

            Assert.Throws<InvalidOperationException>(() => sut.Find2NumbersThatAddUpTo2020AndMultiplyTogether());
        }

        [Test]
        [TestCase(new[] {0, 0})]
        [TestCase(new[] {2020, 1})]
        public void Should_ThrowException_When_Find2NumbersThatAddUpTo2020AndMultiplyTogetherUnableToFindCombination(
            int[] expenseReportEntries)
        {
            var expenseReport = new ExpenseReport {Entries = expenseReportEntries};
            var sut = new ExpenseReportService(expenseReport);

            Assert.Throws<Exception>(() => sut.Find2NumbersThatAddUpTo2020AndMultiplyTogether());
        }

        [Test]
        [TestCase(new[] {2020, 0}, 0)]
        [TestCase(new[] {2019, 1}, 2019)]
        [TestCase(new[] {1, 2, 2018}, 4036)]
        [TestCase(new[] {1721, 979, 366, 299, 675, 1456}, 514579)]
        public void Should_Find2NumbersThatAddUpTo2020AndMultiplyTogether_WhenCombinationExists(
            int[] expenseReportEntries, int expected)
        {
            var expenseReport = new ExpenseReport {Entries = expenseReportEntries};
            var sut = new ExpenseReportService(expenseReport);

            var result = sut.Find2NumbersThatAddUpTo2020AndMultiplyTogether();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}