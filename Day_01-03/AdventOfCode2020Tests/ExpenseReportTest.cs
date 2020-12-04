using System;
using System.Linq;
using AdventOfCode2020.Models;
using AdventOfCode2020.Repositories;
using Moq;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    public class ExpenseReportTest
    {
        [Test]
        public void Should_ThrowException_When_NullPuzzleReportEntriesRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new ExpenseReport(null));
        }
        
        [Test]
        public void Should_PopulateEntries_When_PuzzleReportEntriesRepositoryProvidesThem()
        {
            var entries = new[] {1, 2, 3, 4};
            var mockPuzzleReportEntriesRepository = new Mock<IPuzzleReportEntriesRepository>();
            mockPuzzleReportEntriesRepository
                .Setup(p => p.ReadFile()).Returns(entries);
            var expectedEntries = new[] {1, 2, 3, 4};
            
            var sut = new ExpenseReport(mockPuzzleReportEntriesRepository.Object);
            
            Assert.That(IntArrayRowValuesAreEqual(entries, expectedEntries));
        }
        
        private static bool IntArrayRowValuesAreEqual(int[] row1, int[] row2)
        {
            if (row1.Length != row2.Length)
                return false;

            for (var index = 0; index < row1.Length; index++)
                if (row1.ElementAt(index) != row2.ElementAt(index))
                    return false;

            return true;
        }
    }
}