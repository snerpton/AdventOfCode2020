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

        [Test]
        [TestCase(new object[] {16, 10, 15, 5, 1, 11,  7, 19,  6, 12, 4}, 
                  new object[] { 1,  4,  5, 6, 7, 10, 11, 12, 15, 16, 19}
            )]
        public void Should_ReturnAdaptersInOrder(object[] adaptersAsObj,object[] expectedOrderedAdaptersAsObj)
        {
            var adapters = adaptersAsObj.Select(x => (int)x);
            var expectedOrderedAdapters = expectedOrderedAdaptersAsObj.Select(x => (int)x);
            var sut = new JoltageAdapterService(adapters);

            var actualOrderedAdapters = sut.AdaptersUsedList();
            
            Assert.That(sut.AdaptersUsedList(), Is.EqualTo(expectedOrderedAdapters));
        } 
        
        public void Should_CalculateNumberWith1JoltDifference(object[] adaptersAsObj, int expectedNumWith1JoltDifference)
        {
            var adapters = adaptersAsObj.Select(x => (int)x);
            var sut = new JoltageAdapterService(adapters);
            
            Assert.That(sut.NumberWith1JoltDifference(), Is.EqualTo(expectedNumWith1JoltDifference));
        }
    }
}