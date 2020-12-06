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

        public static int NumberOfQuestionsAnyoneAnsweredYesTo(this GroupResponse groupResponse)
        {
            if (groupResponse == null)
                throw new ArgumentNullException(nameof(groupResponse));

            return groupResponse.QuestionsAnsweredWithYes().Length;
        }
        
        public static int NumberOfQuestionsEveryoneAnsweredYesTo(this GroupResponse groupResponse)
        {
            if (groupResponse == null)
                throw new ArgumentNullException(nameof(groupResponse));

            return groupResponse.QuestionsEveryoneAnsweredWithYes().Length;
        }

        private static string QuestionsEveryoneAnsweredWithYes(this GroupResponse groupResponse)
        {
            if (groupResponse == null)
                throw new ArgumentNullException(nameof(groupResponse));

            var appearInAll = groupResponse.IndividualsResponses[0].YesTo;
            foreach (var response in groupResponse.IndividualsResponses)
            {
                appearInAll = response.YesTo.Where(x => appearInAll.Contains(x)).ToArray();
            }

            appearInAll = appearInAll.OrderBy(x => x).ToArray();
            
            var sb = new StringBuilder();
            foreach (var item in appearInAll)
                sb.Append(item);

            return sb.ToString();
        }
    }
}