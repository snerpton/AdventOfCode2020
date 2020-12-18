using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day9.Models;
using NUnit.Framework;

namespace AdventOfCode2020.Day9.Tests
{
    public class GridPointExtensionsTests
    {
        [Test]
        public void Should_ThrowException_When_NullGridPoints()
        {
            IEnumerable<GridPoint> gridPoints = null;

            Assert.Throws<ArgumentNullException>(() => gridPoints.ToInitialGridFromGridPoints());
        }
        
        [Test]
        public void Should_ThrowException_When_EmptyGridPoints()
        {
            IEnumerable<GridPoint> gridPoints = Enumerable.Empty<GridPoint>();

            Assert.Throws<ArgumentOutOfRangeException>(() => gridPoints.ToInitialGridFromGridPoints());
        }

        [Test]
        [TestCase(new object[]{"."}, 0,0,0)]
        [TestCase(new object[]{"...", "..."}, 0,0,0)]
        [TestCase(new object[]{"..", "..", ".."}, 0,0,0)]
        public void Should_ReturnGridWithCorrectDimensions_When_ValidGridPoints(object[] rowsObj, int expectedXWidth, int expectedYHeight, int expectedZDepth)
        {
            var rows = rowsObj.Select(row => row as string);
            var gridPoints = rows.SelectMany((row,yIndex) => FileParser.ParseXRow(row, yIndex, 0));

            var sut = gridPoints.ToInitialGridFromGridPoints();
            var actualXWidth = sut.GetLength(0);
            var actualYHeight = sut.GetLength(1);
            var actualZDepth = sut.GetLength(2);
            
            Assert.That(actualXWidth, Is.EqualTo(expectedXWidth));
            Assert.That(actualYHeight, Is.EqualTo(expectedYHeight));
            Assert.That(actualZDepth, Is.EqualTo(expectedZDepth));
        }
    }
}