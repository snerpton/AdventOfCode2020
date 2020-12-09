using System;

namespace AdventOfCode2020.Day7
{
    public class BagTypeRule
    {
        public string Bag { get; set; }
        public ChildBagRule[] ChildBags { get; set; }
    }

    public class ChildBagRule
    {
        public string Bag { get; set; }
        public int Number { get; set; }
    }

    public static class BagService
    {
        public static int FindNumberOfBagsThatEventuallyContain(int number, string bag)
        {
            throw new NotImplementedException();
        }
    }
}