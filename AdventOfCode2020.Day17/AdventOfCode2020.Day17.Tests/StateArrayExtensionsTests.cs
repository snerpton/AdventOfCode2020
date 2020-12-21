using System;
using System.Linq;
using AdventOfCode2020.Day17.Models;
using NUnit.Framework;

namespace AdventOfCode2020.Day17.Tests
{
    public class StateArrayExtensionsTests
    {
        [Test]
        public void Should_ThrowException_When_NullStateGrid()
        {
            State[,,,] stateGrid = null;
        
            Assert.Throws<ArgumentNullException>(() => stateGrid.CalculateNumberOfActiveStateCubesAfterIterating(0));
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-10)]
        public void Should_ThrowException_When_NegativeNumberOfIterations(int numberOfIterations)
        {
            var sut = new State[0, 0, 0, 0];
            
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.CalculateNumberOfActiveStateCubesAfterIterating(numberOfIterations));
        }
        
        [Test]
        [TestCase(new object[] {".#.", "..#", "###"}, 6, 848)]
        public void Should_ReturnNumberOfActiveCubes_When_ValidInput(object[] inputRows,
            int numberOfIterations, int expectedNumberActiveCubes)
        {
            var initialGridPoints =
                inputRows.SelectMany((row, yIndex) => FileParser.ParseXRow(row.ToString(), yIndex, 0, 0));
            var sut = initialGridPoints.ToProblemGridFromGridPoints(numberOfIterations);
            
            Assert.That(sut.CalculateNumberOfActiveStateCubesAfterIterating(numberOfIterations), Is.EqualTo(expectedNumberActiveCubes));
        }
    }
}