using NUnit.Framework;

namespace AdventOfCode2020.Day7.Tests
{
    public class BagServiceTests
    {
        [Test]
        [TestCase(1, "shiny gold", 4)]
        public void Should_ReturnNumberOfColoursThatCanEventuallyContainABag_When_BagColourExists(int number, string bagColour, int expectedNumberFound)
        {
            var sut = BagService.FindNumberOfBagsThatEventuallyContain(1, bagColour);

            Assert.That(sut == expectedNumberFound);
        }
    }
}