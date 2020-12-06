using System;

namespace AdventOfCode2020.Day6
{
    public class IndividualsResponse
    {
        public char[] YesTo { get; set; }

        public IndividualsResponse(string yesTo)
        {
            if (string.IsNullOrWhiteSpace(yesTo))
                throw new ArgumentNullException();
            
            throw new NotImplementedException();
        }
    }
}