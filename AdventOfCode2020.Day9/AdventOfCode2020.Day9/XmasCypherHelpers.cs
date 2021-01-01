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

            var preambleIndexMin = 0;
          
            for (var index = preambleCount; index < _inputLines.Count; index++)
            {
                var preamble = CurrentPreamble(preambleIndexMin, preambleCount);
                var target = _inputLines[index];
                
                if (CanFindSumInPreamble(target, preamble) == false)
                {
                    firstInvalidNumber = target;
                    return false;
                }
                
                preambleIndexMin = preambleIndexMin + 1;
            }
            
            return true;
        }
        
        public List<long> FindContiguousSetAddingUpTo(long target)
        {
            if (target <= 0)
                throw new ArgumentOutOfRangeException(nameof(target));

            for (var i = 0; i < _inputLines.Count; i++)
            {
                
            }
            
            
            
            throw new NotImplementedException();
        }
        
        
        
        
        private static bool CanFindSumInPreamble(long target, List<long> preamble)
        {
            for (var i = 0; i < preamble.Count; i++)
            {
                for (var j = i + 1; j < preamble.Count; j++)
                {
                    var num1 = preamble[i];
                    var num2 = preamble[j];
                    if (/*num1 != num2 &&*/ num1 + num2 == target)
                        return true;
                }
            }

            return false;
        }

        private List<long> CurrentPreamble(int rangeIndexMin, int count) =>
            _inputLines.GetRange(rangeIndexMin, count);
    }
}