using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Repositories;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    public class XmasTreeMapRepositoryTests
    {
        private class XmasTreeMapRepositoryWrapper : XmasTreeMapRepository
        {
            public new IEnumerable<MapLocation> MapLocationsFromLine(string line, int yPosition) => base.MapLocationsFromLine(line, yPosition);
            public new IEnumerable<MapLocation> MapLocationsFromLines(string[] lines) => base.MapLocationsFromLines(lines);

        }

        public class MapLocationsFromLineTests
        {
            [Test]
            public void Should_ThrowException_When_NullLine()
            {
                string line = null;
                var sut = new XmasTreeMapRepositoryWrapper();
                
                Assert.Throws<ArgumentNullException>(() => sut.MapLocationsFromLine(line, 0));
            }

            [Test]
            [TestCase(".a.")]
            public void Should_ThrowException_When_InvalidCharacterFoundInMapLine(string line)
            {
                var sut = new XmasTreeMapRepositoryWrapper();

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.MapLocationsFromLine(line, 0));
            }

            [Test]
            [TestCase("", 0, 0)]
            [TestCase("...", 0, 0)]
            [TestCase("###", 0, 3)]
            [TestCase(".#.", 0, 1)]
            [TestCase("#.#", 0, 2)]
            public void Should_CountNumberOfTrees(string line, int yPosition, int expectedCount)
            {
                var sut = new XmasTreeMapRepositoryWrapper();
                
                var treeMap = sut.MapLocationsFromLine(line, yPosition);
                var numberOfTrees = treeMap.Count(x => x.Type == PositionType.Tree);
                
                Assert.That(numberOfTrees == expectedCount);
            }

            [Test]
            public void Should_CreateMap_When_ValidLine()
            {
                var line = ".#.";
                var yPosition = 1;
                var sut = new XmasTreeMapRepositoryWrapper();
                var expectedTreeMap = new List<MapLocation>()
                {
                    new MapLocation{ Type = PositionType.Open, XPosition = 0, YPosition = yPosition},
                    new MapLocation{ Type = PositionType.Tree, XPosition = 1, YPosition = yPosition},
                    new MapLocation{ Type = PositionType.Open, XPosition = 2, YPosition = yPosition}
                };

                var resultTreeMap = sut.MapLocationsFromLine(line, yPosition).ToList();
                
                Assert.That(resultTreeMap.Count() == expectedTreeMap.Count);
                Assert.That(resultTreeMap[0].Type == expectedTreeMap[0].Type);
                Assert.That(resultTreeMap[0].XPosition == expectedTreeMap[0].XPosition);
                Assert.That(resultTreeMap[0].YPosition == expectedTreeMap[0].YPosition);
                Assert.That(resultTreeMap[1].Type == expectedTreeMap[1].Type);
                Assert.That(resultTreeMap[1].XPosition == expectedTreeMap[1].XPosition);
                Assert.That(resultTreeMap[1].YPosition == expectedTreeMap[1].YPosition);
                Assert.That(resultTreeMap[2].Type == expectedTreeMap[2].Type);
                Assert.That(resultTreeMap[2].XPosition == expectedTreeMap[2].XPosition);
                Assert.That(resultTreeMap[2].YPosition == expectedTreeMap[2].YPosition);
            }
        }

        public class MapLocationsFromLinesTests
        {
            [Test]
            public void Should_ThrowException_When_LinesNullCollection()
            {
                var sut = new XmasTreeMapRepositoryWrapper();

                Assert.Throws<ArgumentNullException>(() => sut.MapLocationsFromLines(null));
            }
            
            [Test]
            public void Should_ThrowException_When_LineEmptyCollection()
            {
                var sut = new XmasTreeMapRepositoryWrapper();

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.MapLocationsFromLines(Enumerable.Empty<string>().ToArray()));
            }

            [Test]
            public void Should_CreateMap_When_ValidLines()
            {
                var lines = new string[] {".#.", "#.#"};
                var sut = new XmasTreeMapRepositoryWrapper();
                var expectedTreeMap = new List<MapLocation>()
                {
                    new MapLocation{ Type = PositionType.Open, XPosition = 0, YPosition = 0},
                    new MapLocation{ Type = PositionType.Tree, XPosition = 1, YPosition = 0},
                    new MapLocation{ Type = PositionType.Open, XPosition = 2, YPosition = 0},
                    new MapLocation{ Type = PositionType.Tree, XPosition = 0, YPosition = 1},
                    new MapLocation{ Type = PositionType.Open, XPosition = 1, YPosition = 1},
                    new MapLocation{ Type = PositionType.Tree, XPosition = 2, YPosition = 1},
                };

                var resultTreeMap = sut.MapLocationsFromLines(lines).ToList();
                
                // Line 1
                Assert.That(resultTreeMap.Count() == expectedTreeMap.Count, $"Count: {resultTreeMap.Count()} != {expectedTreeMap.Count}");
                for (var i = 0; i < resultTreeMap.Count; i++)
                {
                    Assert.That(resultTreeMap[i].Type == expectedTreeMap[i].Type, $"Type[{i}]: {resultTreeMap[i].Type} != {expectedTreeMap[i].Type}");
                    Assert.That(resultTreeMap[i].XPosition == expectedTreeMap[i].XPosition, $"XPosition[{i}]: {resultTreeMap[i].XPosition} != {expectedTreeMap[i].XPosition}");
                    Assert.That(resultTreeMap[i].YPosition == expectedTreeMap[i].YPosition, $"YPosition[{i}]: {resultTreeMap[i].YPosition} != {expectedTreeMap[i].YPosition}"); 
                }
            }
        }
    }
}