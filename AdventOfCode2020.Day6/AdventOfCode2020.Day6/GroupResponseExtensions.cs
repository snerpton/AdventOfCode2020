using System;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day6
{
    public static class GroupResponseExtensions
    {
        public static string QuestionsAnsweredWithYes(this GroupResponse groupResponse)
        {
            if (groupResponse == null)
                throw new ArgumentNullException(nameof(groupResponse));
            
            var groupYesTo = groupResponse.IndividualsResponses.SelectMany(x => x.YesTo)
                .Distinct()
                .OrderBy(x => x);
       
            var sb = new StringBuilder();
            foreach (var item in groupYesTo)
                sb.Append(item);

            return sb.ToString();
        }

        public static int SumYesResponse(this GroupResponse groupResponse)
        {
            throw new NotImplementedException();
        }
    }
}