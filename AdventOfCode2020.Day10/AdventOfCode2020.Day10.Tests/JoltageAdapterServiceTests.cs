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
                  new object[] {0, 1,  4,  5, 6, 7, 10, 11, 12, 15, 16, 19, 22}
            )]
        public void Should_ReturnAdaptersInOrder(object[] adaptersAsObj,object[] expectedOrderedAdaptersAsObj)
        {
            var adapters = adaptersAsObj.Select(x => (int)x);
            var expectedOrderedAdapters = expectedOrderedAdaptersAsObj.Select(x => (int)x);
            var sut = new JoltageAdapterService(adapters);

            var actualOrderedAdapters = sut.AdaptersUsedList();
            
            Assert.That(sut.AdaptersUsedList(), Is.EqualTo(expectedOrderedAdapters));
        } 
        
        [Test]
        [TestCase(new object[] {16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4}, 7)]
        [TestCase(new object[]
        {
            28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4,
            2, 34, 10, 3
        }, 22)]
        public void Should_CalculateNumberWith1JoltDifference(object[] adaptersAsObj, int expectedNumWith1JoltDifference)
        {
            var adapters = adaptersAsObj.Select(x => (int)x);
            var sut = new JoltageAdapterService(adapters);
            
            Assert.That(sut.NumberWithJoltDifferenceOf(1), Is.EqualTo(expectedNumWith1JoltDifference));
        }
        
        [Test]
        [TestCase(new object[] {16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4}, 5)]
        [TestCase(new object[]
        {
            28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4,
            2, 34, 10, 3
        }, 10)]
        public void Should_CalculateNumberWith3JoltDifference(object[] adaptersAsObj, int expectedNumWith1JoltDifference)
        {
            var adapters = adaptersAsObj.Select(x => (int)x);
            var sut = new JoltageAdapterService(adapters);
            
            Assert.That(sut.NumberWithJoltDifferenceOf(3), Is.EqualTo(expectedNumWith1JoltDifference));
        }
    }
}