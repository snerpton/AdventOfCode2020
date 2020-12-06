using System;
using System.Linq;

namespace AdventOfCode2020.Day6
{
    public class IndividualsResponse
    {
        public char[] YesTo { get; set; }

        public IndividualsResponse(string yesTo)
        {
            if (string.IsNullOrWhiteSpace(yesTo))
                throw new ArgumentNullException();

            if (ValidateAsUppercase(yesTo) == false)
                throw new ArgumentException(nameof(yesTo));
            
            if (ValidateNoDuplicates(yesTo) == false)
                throw new ArgumentException(nameof(yesTo));
            
            var yesToCharacters = yesTo.Select(x => x);

            YesTo = yesToCharacters.OrderBy(x => x).ToArray();
        }

        private bool ValidateAsUppercase(string letters) =>
            !letters.Any(l => "abcdefghijklmnopqrstuvwxyz".Contains(l));

        private bool ValidateNoDuplicates(string letters) => letters.Distinct().Count() == letters.Length;
    }
}