using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day9
{
    public class XmasCypherHelpers
    {
        private readonly List<long> _inputLines;

        public XmasCypherHelpers(IEnumerable<long> inputLines)
        {
            if (inputLines == null)
                throw new ArgumentNullException(nameof(inputLines));
            
            if (inputLines.Any() == false)
                throw new ArgumentOutOfRangeException(nameof(inputLines));

            _inputLines = inputLines.ToList();
        }

        public bool Validate(int preambleCount, out long firstInvalidNumber)
        {
            if (preambleCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(firstInvalidNumber));

            firstInvalidNumber = long.MinValue;

            var currentPreambleIndexMin = 0;
          
            foreach (var input in _inputLines.GetRange(preambleCount, _inputLines.Count - preambleCount))
            {
                var currentPreamble = CurrentPreamble(currentPreambleIndexMin, preambleCount);

                if (CanFindSumInPreamble(input, currentPreamble) == false)
                {
                    firstInvalidNumber = input;
                    return false;
                }
                
                currentPreambleIndexMin++;
            }
            
            return true;
        }

        private static bool CanFindSumInPreamble(long currentNumber, List<long> preamble)
        {
            for (var i = 0; i < preamble.Count - 1; i++)
            {
                for (var j = i + 1; j < preamble.Count - 1; j++)
                {
                    if (preamble[i] + preamble[j] == currentNumber)
                        return true;
                }
            }

            return false;
        }

        private List<long> CurrentPreamble(int rangeIndexMin, int count) =>
            _inputLines.GetRange(rangeIndexMin, count);
    }
}