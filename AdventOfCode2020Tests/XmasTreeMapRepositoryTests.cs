using System;
using System.Collections.Generic;
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
        }
    }
}