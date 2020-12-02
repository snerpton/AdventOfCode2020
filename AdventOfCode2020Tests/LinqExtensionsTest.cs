using NUnit.Framework;
using AdventOfCode2020.Services;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020Tests
{
    public class LinqExtensionsTest
    {
        public class GetCombinationsOfTwoNumbersTests
        {
            /*
             * Number of combinations = n! / (k! (n-k)! )
             *   = 0! / (2! (0-2)!) = 0 / 0 = ?
             */

            [Test]
            public void Should_ReturnEmptyList_NullListPassedIn()
            {
                int[] collection = null;
                var sut = collection.CombinationsOfTwoNumbersWithoutRepetition();

                Assert.That(sut.Count(), Is.EqualTo(0));
            }


            /*
             * Number of combinations = n! / (k! (n-k)! )
             */
            [Test]
            [TestCase(new int[] { 0 }, 0)] // = 1! / (2! (1-2)!) = 1 / 1 = 1
            [TestCase(new int[] { 0, 1 }, 1)]  // = 2! / (2! (2-2)!) = 2 / 2 = 1
            [TestCase(new int[] { 0, 1, 2 }, 3)]  // = 3! / (2! (3-2)!) = 6 / 2 = 3
            [TestCase(new int[] { 0, 1, 2, 3 }, 6)] // 4! / (2! (4-2)!) = 24 / 3 = 6
            public void Should_ReturnCorrectNumberOfCombinations(int[] collection, int expectedNumberOfCombinations)
            { 
                var sut = collection.CombinationsOfTwoNumbersWithoutRepetition();
                
                Assert.That(sut.Count(), Is.EqualTo(expectedNumberOfCombinations));
            }
            
            [Test]
            public void Should_ReturnCorrectCombinations_When_CollectionCountIs1()
            {
                var source = new[] {0};
                var firstExpectedItem = new[] {0};
                var expected = Enumerable.Empty<int>();
                
                var result = LinqExtensions.CombinationsOfTwoNumbersWithoutRepetition(source).ToArray();
                
                Assert.That(result.Count() == expected.Count());
            }
            
            [Test]
            public void Should_ReturnCorrectCombinations_When_CollectionCountIs2()
            {
                var source = new[] {0, 1};
                var expected = new List<int[]> {new[] {0, 1}};
                
                var result = source.CombinationsOfTwoNumbersWithoutRepetition().ToArray();
                
                Assert.That(result.Length == expected.Count);
                for (var index = 0; index < result.Length; index++)
                {
                    Assert.That(IntArrayRowValuesAreEqual(result.ElementAt(index), expected.ElementAt(index)));
                }
            }
            
            [Test]
            public void Should_ReturnCorrectCombinations_When_CollectionCountIs3()
            {
                var source = new[] {0, 1, 2};
                var expected = new List<int[]> {new[] {0, 1}, new []{0, 2}, new []{1, 2}};
                
                var result = source.CombinationsOfTwoNumbersWithoutRepetition().ToArray();
                
                Assert.That(result.Length == expected.Count);
                for (var index = 0; index < result.Length; index++)
                {
                    Assert.That(IntArrayRowValuesAreEqual(result.ElementAt(index), expected.ElementAt(index)));
                }
            }
            
            [Test]
            public void Should_ReturnCorrectCombinations_When_CollectionCountIs4()
            {
                var source = new[] {0, 1, 2, 3};
                var expected = new List<int[]> {new[] {0, 1}, new []{0, 2}, new []{0, 3}, new []{1, 2}, new []{1, 3}, new []{2, 3}};
                
                var result = source.CombinationsOfTwoNumbersWithoutRepetition().ToArray();
                
                Assert.That(result.Length == expected.Count);
                for (var index = 0; index < result.Length; index++)
                {
                    Assert.That(IntArrayRowValuesAreEqual(result.ElementAt(index), expected.ElementAt(index)));
                }
            }
            
            private static bool IntArrayRowValuesAreEqual(int[] row1, int[] row2)
            {
                if (row1.Length != row2.Length)
                    return false;

                for (var index = 0; index < row1.Length; index++)
                {
                    if (row1.ElementAt(index) != row2.ElementAt(index))
                        return false;
                }

                return true;
            }
        }
    }
}