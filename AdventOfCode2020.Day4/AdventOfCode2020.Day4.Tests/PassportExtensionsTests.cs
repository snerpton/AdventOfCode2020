using System;
using NUnit.Framework;

namespace AdventOfCode2020.Day4.Tests
{
    public class PassportExtensionsTests
    {
        [Test]
        public void Should_ThrowException_When_NullPassport()
        {
            Passport sut = null;
            
            Assert.Throws<ArgumentNullException>(() => sut.Validate());
        }
    }
}