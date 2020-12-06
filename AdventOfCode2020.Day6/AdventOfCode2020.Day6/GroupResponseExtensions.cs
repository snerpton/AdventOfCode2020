using System;

namespace AdventOfCode2020.Day6
{
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