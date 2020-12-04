using System.Data.SqlTypes;
using System.Linq;

namespace AdventOfCode2020.Extensions
{
    public static class StringExtensions
    {
        public static int Occurence(this string haystack, char needle)
        {
            return haystack.Count(x => x == needle);
        }
    }
}