using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Day6
{
    public static class CustomsAnswersFileParser
    {
        public static IEnumerable<GroupResponse> ReadFile()
        {
            var customsAnswersFileAndPath =
                Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) +
                "/Assets/Day6PuzzleInputCustomsAnswers.txt";

            var fileContent = File.ReadAllText(customsAnswersFileAndPath);

            var groupAnswersInput = fileContent.Split(new[] {"\r\n\r\n", "\n\n", "\r\r"},
                StringSplitOptions.RemoveEmptyEntries);

            return groupAnswersInput.Select(x => CreateGroupResponse(x));
        }

        private static GroupResponse CreateGroupResponse(string groupResponse)
        {
            var groupResponseRtn = new GroupResponse();
            foreach (var individualsYesNoResponse in groupResponse.Split(new[] {"\r\n", "\n", "\r"},
                StringSplitOptions.None))
                groupResponseRtn.IndividualsResponses.Add(new IndividualsResponse(individualsYesNoResponse));

            return groupResponseRtn;
        }
    }
}