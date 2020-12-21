using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day9
{
    public class XmasCypherHelpers
    {
        private readonly IEnumerable<long> _inputLines;

        public XmasCypherHelpers(IEnumerable<long> inputLines)
        {
            if (inputLines == null)
                throw new ArgumentNullException(nameof(inputLines));
            
            if (inputLines.Any() == false)
                throw new ArgumentOutOfRangeException(nameof(inputLines));

            _inputLines = inputLines;
        }

        public bool Validate(int preambleCount, out long firstInvalidNumber)
        {
            if (preambleCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(firstInvalidNumber));
            
            throw new NotImplementedException();
        }
    }
}