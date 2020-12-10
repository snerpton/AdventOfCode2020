using System.Text.Json;
using NUnit.Framework;

namespace AdventOfCode2020.Day7.Tests
{
    public class FileParserTests
    {
        public class ParseLineToRuleTests
        {
            [Test]
            public void Should_ParseChildFragmentsIntoChildBags_When_0ChildBagType()
            {
                var line = "clear olive bags contain no other bags.";
                var expected = new BagTypeRule
                {
                    Colour = "clear olive",
                    ChildBags = new ChildBagRule[]{}
                };

                var sut = FileParser.ParseLineToRule(line);
                
                Assert.That(JsonSerializer.Serialize(sut) == JsonSerializer.Serialize(expected));
            }
            
            [Test]
            public void Should_ParseChildFragmentsIntoChildBags_When_1ChildBagType()
            {
                var line = "mirrored gold bags contain 3 light teal bags.";
                var expected = new BagTypeRule
                {
                    Colour = "mirrored gold",
                    ChildBags = new[]{ new ChildBagRule { Bag = "light teal", Number = 3}}
                };

                var sut = FileParser.ParseLineToRule(line);
                
                Assert.That(JsonSerializer.Serialize(sut) == JsonSerializer.Serialize(expected));
            }
            
            [Test]
            public void Should_ParseChildFragmentsIntoChildBags_When_2ChildBagType()
            {
                var line = "clear gold bags contain 5 light maroon bags, 4 pale tomato bags.";
                var expected = new BagTypeRule
                {
                    Colour = "clear gold",
                    ChildBags = new[]{ new ChildBagRule { Bag = "light maroon", Number = 5}, new ChildBagRule { Bag = "pale tomato", Number = 4}}
                };

                var sut = FileParser.ParseLineToRule(line);
                
                Assert.That(JsonSerializer.Serialize(sut) == JsonSerializer.Serialize(expected));
            }
        }
    }
}