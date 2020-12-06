using System;
using System.Linq;

namespace AdventOfCode2020.Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to Advent of Code 200, Day 6!");

            var groupResponses = CustomsAnswersFileParser.ReadFile().ToList();
            
            var numberOfQuestionsAnyoneAnsweredYesTo = groupResponses.Sum(x => x.NumberOfQuestionsAnyoneAnsweredYesTo());
            Console.WriteLine($"Sum of Yes Answers is: {numberOfQuestionsAnyoneAnsweredYesTo}");
            
            var numberOfQuestionsEveryoneAnsweredYesTo = groupResponses.Sum(x => x.NumberOfQuestionsEveryoneAnsweredYesTo());
            Console.WriteLine($"Sum of Yes Answers is: {numberOfQuestionsEveryoneAnsweredYesTo}");
        }
    }
}