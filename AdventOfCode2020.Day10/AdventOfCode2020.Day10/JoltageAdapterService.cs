using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day10
{
    public class JoltageAdapterService
    {
        private readonly IEnumerable<int> _adapters;
        private readonly int _minStepJoltDifference = 1;
        private readonly int _maxStepJoltDifference = 3;
        private readonly int _startingJoltage = 0;

        public JoltageAdapterService(IEnumerable<int> adapters)
        {
            if (adapters == null)
                throw new ArgumentNullException(nameof(adapters));

            if (adapters.Any() == false)
                throw new ArgumentOutOfRangeException(nameof(adapters));

            _adapters = adapters;
        }

        public int CalculateDeviceJoltageRating() => _adapters.Max() + 3;

        public int NumberWith1JoltDifference()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> AdaptersUsedList()
        {
            var adapters = _adapters.ToList();
            var orderedAdapters = new List<int>();
            var currentJoltage = _startingJoltage;
            
            
            while (adapters.Any())
            {
                var nextAdapter = SelectNextAdapter(adapters, currentJoltage);
                adapters.Remove(nextAdapter);
                orderedAdapters.Add(nextAdapter);
                currentJoltage = nextAdapter;
            }

            return orderedAdapters;
        }

        private int SelectNextAdapter(List<int> adapters, int currentJoltage)
        {
            // Assumptions:
            // - only one path through selection of adapters
            // - no duplicates
            for (var joltageStep = _minStepJoltDifference; joltageStep <= _maxStepJoltDifference; joltageStep++)
            {
                if (adapters.Any(x => x == currentJoltage + joltageStep))
                    return currentJoltage + joltageStep;
            }

            throw new Exception();
        }
    }
}