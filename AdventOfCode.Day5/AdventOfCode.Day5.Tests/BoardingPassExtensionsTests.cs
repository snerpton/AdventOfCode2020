using System;
using NUnit.Framework;

namespace AdventOfCode.Day5.Tests
{
    public class BoardingPassExtensionsTests
    {
        [Test]
        public void Should_ThrowException_When_NullBoardingPass()
        {
            string sut = null;
            
            Assert.Throws<ArgumentNullException>(() => BoardingPassExtensions.IsValidSeat(sut));
        }

        public class IsValidTests
        {
            [Test]
            public void Should_ThrowException_When_NullBoardingPass()
            {
                Assert.Throws<ArgumentNullException>(() => BoardingPassExtensions.IsValid(null));
            }
            
            [Test]
            public void Should_ReturnTrue_When_ValidBoardingPass()
            {
                var boardingPass = new BoardingPass("FFFFFFFLLL");
                
                Assert.That(() => BoardingPassExtensions.IsValid(boardingPass) == true);
            }
        }
        
        public class IsValidSeatTests
        {
            [Test]
            public void Should_ReturnThrowException_When_NullSeat()
            {
                Assert.Throws<ArgumentNullException>(() => BoardingPassExtensions.IsValidSeat(null));
            } 
            
            [Test]
            [TestCase("FFFFFFFZLL")]
            [TestCase("FFFFFFFFLL")]
            public void Should_ReturnFalse_When_SeatColContainsInValidCharacters(string seat)
            {
                Assert.That(BoardingPassExtensions.IsValidSeat(seat) == false);
            }    
            
            [Test]
            [TestCase("ZFFFFFFLLL")]
            [TestCase("LFFFFFFLLL")]
            public void Should_ReturnFalse_When_SeatRowContainsInValidCharacters(string seat)
            {
                Assert.That(BoardingPassExtensions.IsValidSeat(seat) == false);
            }   
            
            [Test]
            [TestCase("FFFFFFFFLLL")]
            [TestCase("FFFFFFFLLLL")]
            
            public void Should_ReturnFalse_When_SeatInValidNumberOfCharacters(string seat)
            {
                Assert.That(BoardingPassExtensions.IsValidSeat(seat) == false);
            }   
            
            [Test]
            [TestCase("FBFBBFFRLR")]
            [TestCase("BFFFBBFRRR")]
            [TestCase("FFFBBBFRRR")]
            [TestCase("BBFFBBFRLL")]
            public void Should_ReturnTrue_When_SeatIsValid(string seat)
            {
                Assert.That(BoardingPassExtensions.IsValidSeat(seat) == true);
            }  
        }
    }
}