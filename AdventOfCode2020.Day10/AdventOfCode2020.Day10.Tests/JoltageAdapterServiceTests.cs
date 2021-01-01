using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day10.Tests
{
    public class JoltageAdapterServiceTests
    {
        [Test]
        public void Should_ThrowException_When_NullAdapters()
        {
            IEnumerable<int> adapters = null;

            Assert.Throws<ArgumentNullException>(() => new JoltageAdapterService(adapters));
        }
        
        [Test]
        public void Should_ThrowException_When_EmptyAdapters()
        {
            var adapters = Enumerable.Empty<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => new JoltageAdapterService(adapters));
        }

        [Test]
        [TestCase(new object[]{1,2,3}, 6)]
        [TestCase(new object[]{3,2,1}, 6)]
        [TestCase(new object[]{16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4}, 22)]
        public void Should_CalculateDeviceJoltageRating(object[] adaptersAsObj, int expectedDeviceJoltrating)
        {
            var adapters = adaptersAsObj.Select(x => (int)x);
            var sut = new JoltageAdapterService(adapters);
            
            Assert.That(sut.CalculateDeviceJoltageRating(), Is.EqualTo(expectedDeviceJoltrating));
        }
    }
}