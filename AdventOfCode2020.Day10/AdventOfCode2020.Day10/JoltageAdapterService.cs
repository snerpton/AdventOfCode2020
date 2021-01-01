using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day10
{
    public class JoltageAdapterService
    {
        private readonly IEnumerable<int> _adapters;

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
    }
}