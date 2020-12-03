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
            public new IEnumerable<MapLocation> MapLocationsFromLine(string line) => base.MapLocationsFromLine(line);
        }

        public class MapLocationsFromLineTests
        {
            [Test]
            public void Should_ThrowException_When_NullLine()
            {
                string line = null;
                var sut = new XmasTreeMapRepositoryWrapper();
                
                Assert.Throws<ArgumentNullException>(() => sut.MapLocationsFromLine(line));
            }

            [Test]
            [TestCase("", 0)]
            [TestCase("...", 0)]
            [TestCase("###", 3)]
            [TestCase(".#.", 1)]
            [TestCase("#.#", 2)]
            public void Should_CountNumberOfTrees(string line, int expectedCount)
            {
                var sut = new XmasTreeMapRepositoryWrapper();
                
                var treeMap = sut.MapLocationsFromLine(line);
                var numberOfTrees = treeMap.Count(x => x.Type == PositionType.Tree);
                
                Assert.That(numberOfTrees == expectedCount);
            }
        }
    }
}