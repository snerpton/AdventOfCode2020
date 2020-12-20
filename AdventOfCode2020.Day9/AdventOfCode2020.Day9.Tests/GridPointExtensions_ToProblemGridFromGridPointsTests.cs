using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AdventOfCode2020.Day9.Models;
using NUnit.Framework;

namespace AdventOfCode2020.Day9.Tests
{
    public class GridPointExtensions_ToProblemGridFromGridPointsTests
    {
        [Test]
        public void Should_ThrowException_When_NullGridPoints()
        {
            IEnumerable<GridPoint> gridPoints = null;
            const int numberOgIterations = 0;

            Assert.Throws<ArgumentNullException>(() => gridPoints.ToProblemGridFromGridPoints(numberOgIterations));
        }
        
        [Test]
        public void Should_ThrowException_When_EmptyGridPoints()
        {
            var gridPoints = Enumerable.Empty<GridPoint>();
            const int numberOgIterations = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => gridPoints.ToProblemGridFromGridPoints(numberOgIterations));
        }

        
        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-10)]
        public void Should_ThrowException_When_NegativeNumberOfIterations(int numberOfIterations)
        {
            var rows = new []{"."};
            var sut = rows.SelectMany((row,yIndex) => FileParser.ParseXRow(row, yIndex, 0, 0));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                sut.ToProblemGridFromGridPoints(numberOfIterations));
        }
        
        [Test]
        [TestCase(new object[]{"."}, 0, 1,1,1, 1)]
        [TestCase(new object[]{"."}, 1, 3,3,3, 3)]
        [TestCase(new object[]{"."}, 2, 5,5,5, 5)]
        [TestCase(new object[]{"."}, 3, 7,7,7, 7)]
        public void Should_ReturnProblemGridWithCorrectDimensions_When_ValidGridPoints(object[] rowsObj,
            int numberOfIterations, int expectedXWidth, int expectedYHeight, int expectedZDepth, int expectedWDimension)
        {
            var rows = rowsObj.Select(row => row as string);
            var gridPoints = rows.SelectMany((row,yIndex) => FileParser.ParseXRow(row, yIndex, 0, 0));

            var sut = gridPoints.ToProblemGridFromGridPoints(numberOfIterations);
            var actualXWidth = sut.GetLength(0);
            var actualYHeight = sut.GetLength(1);
            var actualZDepth = sut.GetLength(2);
            var actualWDimension = sut.GetLength(3);
            
            Assert.That(actualXWidth, Is.EqualTo(expectedXWidth));
            Assert.That(actualYHeight, Is.EqualTo(expectedYHeight));
            Assert.That(actualZDepth, Is.EqualTo(expectedZDepth));
            Assert.That(actualWDimension, Is.EqualTo(expectedWDimension));
        }

        [Test]
        public void Should_CreateProblemGrid_When_ValidGridPointsSinglePoint0Iteration()
        {
            var rows = new[]{"#"};
            var gridPoints = rows.SelectMany((row,yIndex) => FileParser.ParseXRow(row, yIndex, 0, 0));
            const int numberOfIterations = 0;
            var expectedActivePoints = new List<GridPoint>()
            {
                new GridPoint {X = 0, Y = 0, Z = 0, W = 0, State = State.Active}
            };
            
            var sut = gridPoints.ToProblemGridFromGridPoints(numberOfIterations);
            var actualActivePoints = new List<GridPoint>();
        
            for (var x = 0; x < sut.GetLength(0); x++)
            for (var y = 0; y < sut.GetLength(1); y++)
            for (var z = 0; z < sut.GetLength(2); z++)
            for (var w = 0; w < sut.GetLength(3); w++)
                if (sut[x, y, z, w] == State.Active)
                    actualActivePoints.Add(new GridPoint {X = x, Y = y, Z = z, W = w, State = State.Active});


            Assert.That(actualActivePoints.Count == expectedActivePoints.Count);
            Assert.That(JsonSerializer.Serialize(actualActivePoints) == JsonSerializer.Serialize(expectedActivePoints));
        }
        
        [Test]
        public void Should_CreateProblemGrid_When_ValidGridPointsSinglePoint1Iteration()
        {
            var rows = new[]{"#"};
            var gridPoints = rows.SelectMany((row,yIndex) => FileParser.ParseXRow(row, yIndex, 0, 0));
            const int numberOfIterations = 1;
            var expectedActivePoints = new List<GridPoint>()
            {
                new GridPoint {X = 1, Y = 1, Z = 1, W = 1, State = State.Active}
            };
            
            var sut = gridPoints.ToProblemGridFromGridPoints(numberOfIterations);
            var actualActivePoints = new List<GridPoint>();
        
            for (var x = 0; x < sut.GetLength(0); x++)
            for (var y = 0; y < sut.GetLength(1); y++)
            for (var z = 0; z < sut.GetLength(2); z++)
            for (var w = 0; w < sut.GetLength(3); w++)
                if (sut[x, y, z, w] == State.Active)
                    actualActivePoints.Add(new GridPoint {X = x, Y = y, Z = z, W = w, State = State.Active});


            Assert.That(actualActivePoints.Count == expectedActivePoints.Count);
            Assert.That(JsonSerializer.Serialize(actualActivePoints) == JsonSerializer.Serialize(expectedActivePoints));
        }
        
        [Test]
        public void Should_CreateProblemGrid_When_ValidGridPoints2by2WithIteration()
        {
            var rows = new[]{"#.", ".#"};
            var gridPoints = rows.SelectMany((row,yIndex) => FileParser.ParseXRow(row, yIndex, 0, 0));
            const int numberOfIterations = 2;
            var expectedActivePoints = new List<GridPoint>()
            {
                new GridPoint {X = 2, Y = 2, Z = 2, W = 2, State = State.Active},
                new GridPoint {X = 3, Y = 3, Z = 2, W = 2, State = State.Active}
            };
            
            var sut = gridPoints.ToProblemGridFromGridPoints(numberOfIterations);
            var actualActivePoints = new List<GridPoint>();
        
            for (var x = 0; x < sut.GetLength(0); x++)
            for (var y = 0; y < sut.GetLength(1); y++)
            for (var z = 0; z < sut.GetLength(2); z++)
            for (var w = 0; w < sut.GetLength(3); w++)
                if (sut[x, y, z, w] == State.Active)
                    actualActivePoints.Add(new GridPoint {X = x, Y = y, Z = z, W = w, State = State.Active});

            Assert.That(actualActivePoints.Count == expectedActivePoints.Count);
            Assert.That(JsonSerializer.Serialize(actualActivePoints) == JsonSerializer.Serialize(expectedActivePoints));
        }
    }
}