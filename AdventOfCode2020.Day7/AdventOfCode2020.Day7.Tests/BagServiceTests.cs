using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day7.Tests
{
    public static class DemoValidRules
    {
        public static BagTypeRule[] Rules =
        {
            new BagTypeRule
            {
                Colour = "light red",
                ChildBags = new[]
                {
                    new ChildBagRule {Bag = "bright white", Number = 1},
                    new ChildBagRule {Bag = "muted yellow", Number = 2}
                }
            },
            new BagTypeRule
            {
                Colour = "dark orange",
                ChildBags = new[]
                {
                    new ChildBagRule {Bag = "bright white", Number = 3},
                    new ChildBagRule {Bag = "muted yellow", Number = 4}
                }
            },
            new BagTypeRule
            {
                Colour = "bright white",
                ChildBags = new[]
                {
                    new ChildBagRule {Bag = "shiny gold", Number = 1}
                }
            },
            new BagTypeRule
            {
                Colour = "muted yellow",
                ChildBags = new[]
                {
                    new ChildBagRule {Bag = "shiny gold", Number = 2},
                    new ChildBagRule {Bag = "faded blue", Number = 9}
                }
            },
            new BagTypeRule
            {
                Colour = "shiny gold",
                ChildBags = new[]
                {
                    new ChildBagRule {Bag = "dark olive", Number = 1},
                    new ChildBagRule {Bag = "vibrant plum", Number = 2}
                }
            },
            new BagTypeRule
            {
                Colour = "dark olive",
                ChildBags = new[]
                {
                    new ChildBagRule {Bag = "faded blue", Number = 3},
                    new ChildBagRule {Bag = "dotted black", Number = 4}
                }
            },
            new BagTypeRule
            {
                Colour = "vibrant plum",
                ChildBags = new[]
                {
                    new ChildBagRule {Bag = "faded blue", Number = 5},
                    new ChildBagRule {Bag = "dotted black", Number = 6}
                }
            },
            new BagTypeRule
            {
                Colour = "faded blue",
                ChildBags = new ChildBagRule[] { }
            },
            new BagTypeRule
            {
                Colour = "dotted black",
                ChildBags = new ChildBagRule[] { }
            }
        };
    }
    
    public class BagServiceTests
    {
        [Test]
        public void Should_ThrowException_When_NullBagRules()
        {
            Assert.Throws<ArgumentNullException>(() => new BagService(null));
        }

        [Test]
        public void Should_ThrowException_When_RuleBagColourNotUnique()
        {
            var bagRuleContainingNoneUniqueRuleColor = DemoValidRules.Rules.ToList();
            bagRuleContainingNoneUniqueRuleColor.Add(new BagTypeRule{ Colour = "duplicateColour"});
            bagRuleContainingNoneUniqueRuleColor.Add(new BagTypeRule{ Colour = "duplicateColour"});

            Assert.Throws<ArgumentException>(() => new BagService(bagRuleContainingNoneUniqueRuleColor.ToArray()));
        }
        
        public class FindNumberOfBagsThatEventuallyContain
        {
            [Test]
            [TestCase(null)]
            public void Should_ThrowException_When_NullColourProvided(string bagColour)
            {
                var sut = new BagService(DemoValidRules.Rules.ToArray());
                
                Assert.Throws<ArgumentNullException>(() => sut.FindNumberOfBagsThatEventuallyContain(bagColour));
            }
            
            [Test]
            [TestCase("colourThatDoesntExist")]
            public void Should_ThrowException_When_ColourNotFound(string bagColour)
            {
                var sut = new BagService(DemoValidRules.Rules.ToArray());
                
                Assert.Throws<ArgumentException>(() => sut.FindNumberOfBagsThatEventuallyContain(bagColour));
            }
            
            [Test]
            [TestCase("shiny gold", 4)]
            public void Should_ReturnNumberOfColoursThatCanEventuallyContainABag_When_BagColourExists(string bagColour, int expectedNumberFound)
            {
                var sut = new BagService(DemoValidRules.Rules.ToArray());
                var actualNumberFound = sut.FindNumberOfBagsThatEventuallyContain(bagColour);
            
                Assert.That(actualNumberFound == expectedNumberFound);
            }         
        }

        public class TotalNumberOfBagsContainedIn
        {
            [Test]
            [TestCase(null)]
            public void Should_ThrowException_When_NullColourProvided(string bagColour)
            {
                var sut = new BagService(DemoValidRules.Rules.ToArray());
                
                Assert.Throws<ArgumentNullException>(() => sut.TotalNumberOfBagsContainedIn(bagColour));
            }
            
            [Test]
            [TestCase("colourThatDoesntExist")]
            public void Should_ThrowException_When_ColourNotFound(string bagColour)
            {
                var sut = new BagService(DemoValidRules.Rules.ToArray());
                
                Assert.Throws<ArgumentException>(() => sut.TotalNumberOfBagsContainedIn(bagColour));
            }

        }
    }
}