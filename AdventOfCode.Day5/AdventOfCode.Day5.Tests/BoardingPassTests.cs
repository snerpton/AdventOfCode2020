using System;
using NUnit.Framework;

namespace AdventOfCode.Day5.Tests
{
    public class BoardingPassTests
    {
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_ThrowException_When_NullOrEmptyWhitespaceSeat(string seat)
        {
            Assert.Throws<ArgumentNullException>(() => new BoardingPass(seat));
        }      
    }
}