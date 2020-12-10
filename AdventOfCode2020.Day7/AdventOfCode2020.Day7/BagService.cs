using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day7
{
    public class BagService
    {
        private BagTypeRule[] _bagRules;

        public BagService(BagTypeRule[] bagRules)
        {
            _bagRules = bagRules ?? throw new ArgumentNullException(nameof(bagRules));
            
            if (bagRules.Select(rule => rule.Colour).Distinct().Count() != _bagRules.Length)
                throw new ArgumentException();
        }
        
        public int FindNumberOfBagsThatEventuallyContain(string bag)
        {   
            if (string.IsNullOrEmpty(bag))
                throw new ArgumentNullException(nameof(bag));
            
            if (_bagRules.Select(rule => rule.Colour).Contains(bag) == false)
                throw new ArgumentException(nameof(bag),$"Bag colour ({bag}) not found.");

            var rulesContainingBagNotAtRoot = FindRuleContainingBag(bag);
            
            return rulesContainingBagNotAtRoot.Distinct().Count();
        }
        
        private BagTypeRule[] FindRuleContainingBag(string bag)
        {
            var newBags = _bagRules.Where(rule => rule.ChildBags.Select(childBag => childBag.Bag).Contains(bag)).ToList();
            var runningTotal = new List<BagTypeRule>();
            runningTotal.AddRange(newBags);
            
            foreach (var newBag in newBags)
            {
                runningTotal.AddRange(FindRuleContainingBag(newBag.Colour));
            }
            
            return runningTotal.ToArray();
        }
        
        public int TotalNumberOfBagsContainedIn(string bag)
        {
            if (string.IsNullOrEmpty(bag))
                throw new ArgumentNullException(nameof(bag));
            
            if (_bagRules.Select(rule => rule.Colour).Contains(bag) == false)
                throw new ArgumentException(nameof(bag),$"Bag colour ({bag}) not found.");

            var rootBags = _bagRules.Where(b => b.Colour == bag);
            
            if (!rootBags.Any() || rootBags.Count() > 1)
                throw new ArgumentOutOfRangeException(nameof(bag));

            var rootBag = rootBags.First();

            var found = FindDescendantBags(rootBag.Colour);
            return found;
        }

        private int FindDescendantBags(string bag)
        {
            var rootBag = _bagRules.First(b => b.Colour == bag);
            var total = 0;
            foreach (var childBag in rootBag.ChildBags)
            {
                total = total + childBag.Number + childBag.Number * FindDescendantBags(childBag.Bag);
            }

            return total;
        }
    }
}