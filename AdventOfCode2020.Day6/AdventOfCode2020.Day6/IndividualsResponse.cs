using System;
using System.Collections.Generic;

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

    public class GroupResponse
    {
        public IEnumerable<IndividualsResponse> IndividualsResponses { get; set; }
    }

    public static class GroupResponseExtensions
    {
        public static string[] QuestionsAnsweredWithYes(this GroupResponse groupResponse)
        {
            if (groupResponse == null)
                throw new ArgumentNullException(nameof(groupResponse));
            
            return new string[]{};
        }
    }
}