using System;
using Moq;
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

        public class ColumnTests
        {
            [Test]
            public void Should_ThrowException_When_NullBoardingPass()
            {
                BoardingPass sut = null; 
                
                Assert.Throws<ArgumentNullException>(() => sut.Column());
            }
            
            [Test]
            [TestCase("FFFFFFFXXX")]
            [TestCase("XXXXXXXLLL")]
            [TestCase("aaa")]
            public void Should_ThrowException_When_InValidSeat(string seat)
            {
                var mockBoardingPass = new Mock<IBoardingPass>();
                mockBoardingPass.SetupGet(m => m.Seat).Returns(seat);

                Assert.Throws<ArgumentException>(() => BoardingPassExtensions.Column(mockBoardingPass.Object));
            }
            
            [Test]
            [TestCase("FBFBBFFRLR", 5)]
            [TestCase("BFFFBBFRRR", 7)]
            [TestCase("FFFBBBFRRR", 7)]
            [TestCase("BBFFBBFRLL", 4)]
            public void Should_ReturnCol_When_SeatIsValid(string seat, int expectedColPosition)
            {
                var sut = new BoardingPass(seat);
                
                Assert.That(sut.Column() == expectedColPosition);
            }
        }
        
        public class RowTests
        {
            [Test]
            public void Should_ThrowException_When_NullBoardingPass()
            {
                BoardingPass sut = null; 
                
                Assert.Throws<ArgumentNullException>(() => sut.Row());
            }
            
            [Test]
            [TestCase("FFFFFFFXXX")]
            [TestCase("XXXXXXXLLL")]
            [TestCase("aaa")]
            public void Should_ThrowException_When_InValidSeat(string seat)
            {
                var mockBoardingPass = new Mock<IBoardingPass>();
                mockBoardingPass.SetupGet(m => m.Seat).Returns(seat);

                Assert.Throws<ArgumentException>(() => BoardingPassExtensions.Row(mockBoardingPass.Object));
            }
            
            [Test]
            [TestCase("FBFBBFFRLR", 44)]
            [TestCase("BFFFBBFRRR", 70)]
            [TestCase("FFFBBBFRRR", 14)]
            [TestCase("BBFFBBFRLL", 102)]
            public void Should_ReturnRow_When_SeatIsValid(string seat, int expectedRowPosition)
            {
                var sut = new BoardingPass(seat);
                
                Assert.That(sut.Row() == expectedRowPosition);
            }
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
            [TestCase("")]
            [TestCase("   ")]
            public void Should_ReturnFalse_When_SeatIsEmptyString(string seat)
            {
                Assert.That(BoardingPassExtensions.IsValidSeat(seat) == false);
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