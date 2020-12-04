using System;
using System.Collections.Generic;
using AdventOfCode2020.Repositories;
using AdventOfCode2020.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode2020Tests
{
    public class XmasTreeMapServiceTests
    {
        private class XmasTreeMapRepositoryWrapper : XmasTreeMapRepository
        {
            public new IEnumerable<MapLocation> MapLocationsFromLine(string line, int yPosition) => base.MapLocationsFromLine(line, yPosition);
            public new IEnumerable<MapLocation> MapLocationsFromLines(string[] lines) => base.MapLocationsFromLines(lines);
        }
        
        [Test]
        public void Should_ThrowException_When_NullXmasTreeMap()
        {
            Assert.Throws<ArgumentNullException>(() => new XmasTreeMapService(null, 1, 1));
        }
        
        [Test]
        public void Should_ThrowException_When_EmptyXmasTreeMap()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new XmasTreeMapService(new List<MapLocation>(), 1, 1));
        }
        
        [Test]
        [TestCase(-1,1)]
        [TestCase(1,-1)]
        public void Should_ThrowException_When_InvalidSingleMoves(int singleMoveX, int singleMoveY)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new XmasTreeMapService(new List<MapLocation>(), singleMoveX, singleMoveY));
        }

        public class CountTreesTests
        {
            [Test]
            public void Should_CalculateNumberOfTrees()
            {
                var lines = new List<string>
                {
                    "..##.......",
                    "#...#...#..",
                    ".#....#..#.",
                    "..#.#...#.#",
                    ".#...##..#.",
                    "..#.##.....",
                    ".#.#.#....#",
                    ".#........#",
                    "#.##...#...",
                    "#...##....#",
                    ".#..#...#.#"
                };

                int singleMoveX = 3;
                int singleMoveY = 1;
                var expectedNumberOfTrees = 7;
                var xmasTreeMap = new XmasTreeMapRepositoryWrapper();
                var sut = new XmasTreeMapService(xmasTreeMap.MapLocationsFromLines(lines.ToArray()), singleMoveX, singleMoveY);
                
                var resultNumberOfTrees = sut.CountTrees();
                
                Assert.That(resultNumberOfTrees == expectedNumberOfTrees, $"{resultNumberOfTrees} : {expectedNumberOfTrees}");
            }
        }
    }
}