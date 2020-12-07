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
        
        [TestCase("aaa")]
        public void Should_SetSeat_When_SeatProvided(string seat)
        {
            var sut = new BoardingPass(seat);
            
            Assert.That(sut.Seat == seat);
        }  
    }
}