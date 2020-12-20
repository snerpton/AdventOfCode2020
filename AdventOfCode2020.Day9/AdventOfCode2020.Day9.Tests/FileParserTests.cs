using System;
using System.Linq;
using AdventOfCode2020.Day9.Models;
using NUnit.Framework;

namespace AdventOfCode2020.Day9.Tests
{
    public class FileParserTests
    {
        
        [Test]
        [TestCase(null)]
        public void Should_ThrowException_When_NullOrEmptyRow(string row)
        {
            const int y = 0;
            const int z = 0;
            const int w = 0;

            Assert.Throws<ArgumentNullException>(() => FileParser.ParseXRow(row, y, z, w));
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        [TestCase("a")]
        [TestCase(".a.")]
        [TestCase("##a")]
        public void Should_ThrowException_When_InvalidCharacterInRow(string row)
        {
            const int y = 0;
            const int z = 0;
            const int w = 0;
            
            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.ParseXRow(row, y, z, w));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-10)]
        public void Should_ThrowException_When_NegativeYPosition(int y)
        {
            const string row = ".";
            const int z = 0;
            const int w = 0; 
            
            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.ParseXRow(row, y, z, w));  
        } 
        
        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-10)]
        public void Should_ThrowException_When_NegativeZPosition(int z)
        {
            const string row = ".";
            const int y = 0;
            const int w = 0;
            
            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.ParseXRow(row, y, z, w));  
        } 
        
        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-10)]
        public void Should_ThrowException_When_NegativeWPosition(int w)
        {
            const string row = ".";
            const int y = 0; 
            const int z = 0; 
            
            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.ParseXRow(row, y, z, w));  
        } 
        
        [Test]
        [TestCase(".", new object []{State.Inactive})]
        [TestCase("#", new object []{State.Active})]
        [TestCase("...", new object []{State.Inactive, State.Inactive, State.Inactive})]
        [TestCase(".#.", new object []{State.Inactive, State.Active, State.Inactive})]
        public void Should_ParseRowState_When_ValidInput(string xRow, object[] expectedStatesObj)
        {
            var expectedStates = expectedStatesObj.Select(s => s is State ? (State) s : State.Active);
            const int y = 0;
            const int z = 0;
            const int w = 0;
            
            var sut = FileParser.ParseXRow(xRow, y, z, w);
            
            Assert.That(sut.Select(p => p.State).SequenceEqual<State>(expectedStates));
        }
        
        [Test]
        [TestCase(".", 0, 0, 0, 0, 0, 0)]
        [TestCase("...", 1, 0, 0, 1, 0, 0)]
        [TestCase("...", 0, 1, 0, 0, 1, 0)]
        [TestCase("...", 0, 0, 1, 0, 0, 1)]
        [TestCase(".#.", 0, 3, 0, 0, 3, 0)]
        public void Should_ParseRowYAndZAndW_When_ValidInput(string xRow, int y, int z, int w, int expectedY, int expectedZ, int expectedW)
        {
            var sut = FileParser.ParseXRow("...", y, z, w);

            Assert.That(sut.Select(point => point.Y).All(y => y == expectedY));
            Assert.That(sut.Select(point => point.Z).All(z => z == expectedZ));
            Assert.That(sut.Select(point => point.W).All(w => w == expectedW));
        }
    }
}