using NUnit.Framework;

namespace AdventOfCode.Day5.Tests
{
    public class BoardingPassExtensionsTests
    {
        public class IsValidTests
        {
            [Test]
            [TestCase("ZFFFFFFLLL")]
            [TestCase("LFFFFFFLLL")]
            [TestCase(null)]
            public void Should_ReturnFalse_When_SeatRowContainsInValidCharacters(string seat)
            {
                var sut = new BoardingPass(seat);
                
                Assert.That(sut.IsValid() == false);
            }    
            
            [Test]
            [TestCase("FFFFFFFZLL")]
            [TestCase("FFFFFFFFLL")]
            [TestCase(null)]
            public void Should_ReturnFalse_When_SeatColContainsInValidCharacters(string seat)
            {
                var sut = new BoardingPass(seat);
                
                Assert.That(sut.IsValid() == false);
            }    
            
            [Test]
            [TestCase("FFFFFFFFLLL")]
            [TestCase("FFFFFFFLLLL")]
            [TestCase(null)]
            public void Should_ReturnFalse_When_SeatInValidNumberOfCharacters(string seat)
            {
                var sut = new BoardingPass(seat);
                
                Assert.That(sut.IsValid() == false);
            }   
            
            [Test]
            [TestCase("FBFBBFFRLR")]
            [TestCase("BFFFBBFRRR")]
            [TestCase("FFFBBBFRRR")]
            [TestCase("BBFFBBFRLL")]
            [TestCase(null)]
            public void Should_ReturnTrue_When_SeatIsValid(string seat)
            {
                var sut = new BoardingPass(seat);
                
                Assert.That(sut.IsValid() == true);
            }  
        }
    }
}