using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<int[]> CombinationsOfTwoNumbersWithoutRepetition(this IEnumerable<int> source)
        {
            if (source == null)
                return Enumerable.Empty<int[]>();

            var combinations = new List<int[]>();
            var sourceArray = source as int[] ?? source.ToArray();

            for (var i = 0; i < sourceArray.Length; i++)
            for (var j = 0; j < sourceArray.Length; j++)
                if (i != j && j > i)
                    combinations.Add(new[] {sourceArray.ElementAt(i), sourceArray.ElementAt(j)});

            return combinations;
        }
        
        public static IEnumerable<int[]> CombinationsOfThreeNumbersWithoutRepetition(this IEnumerable<int> source)
        {
            if (source == null)
                return Enumerable.Empty<int[]>();

            var combinations = new List<int[]>();
            var sourceArray = source as int[] ?? source.ToArray();

            for (var i = 0; i < sourceArray.Length; i++)
            for (var j = 0; j < sourceArray.Length; j++)
            for (var k = 0; k < sourceArray.Length; k++)
                if (i != j && i != k && j != k && j > i && k > j && k > i)
                    combinations.Add(new[] {sourceArray.ElementAt(i), sourceArray.ElementAt(j), sourceArray.ElementAt(k)});

            return combinations;
        }
    }
}