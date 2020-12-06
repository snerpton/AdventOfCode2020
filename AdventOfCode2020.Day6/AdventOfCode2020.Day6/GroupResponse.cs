using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day6
{
    public class GroupResponse
    {
        public IEnumerable<IndividualsResponse> IndividualsResponses { get; set; } = Enumerable.Empty<IndividualsResponse>();
    }
}