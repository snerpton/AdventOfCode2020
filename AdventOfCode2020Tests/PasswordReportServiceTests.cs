using System;
using AdventOfCode2020.Services;
using NUnit.Framework;

namespace AdventOfCode2020Tests
{
    public class PasswordReportServiceTests
    {
        [Test]
        public void Should_ThrowException_When_NullPasswordReport()
        {
            Assert.Throws<ArgumentNullException>(() => new PasswordReportService(null));
        }
    }
}