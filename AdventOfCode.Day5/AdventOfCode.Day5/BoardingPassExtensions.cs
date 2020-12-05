using System;
using System.Linq;

namespace AdventOfCode.Day5
{
    public static class BoardingPassExtensions
    {
        private static readonly char[] ValidColChars = {'L', 'R'};
        private static readonly char[] ValidRowChars = {'F', 'B'};
        private static readonly int NumberCharsInColDescription = 3;
        private static readonly int NumberCharsInRowDescription = 7;
        private static readonly int ColCharStartIndexInSeat = 7;
        private static readonly int RowCharStartIndexInSeat = 0;
        
        public static int Column(this string boardingPass)
        {
            throw new NotImplementedException();
        }

        public static bool IsValid(BoardingPass boardingPass)
        {
            if (boardingPass == null)
                throw new ArgumentNullException(nameof(boardingPass));

            return IsValidSeat(boardingPass.Seat);
        }

        public static bool IsValidSeat(string boardingPass)
        { 
            if (boardingPass == null)
                throw new ArgumentNullException(nameof(boardingPass));

            if (string.IsNullOrWhiteSpace(boardingPass))
                return false;

            if (boardingPass.Length != NumberCharsInColDescription + NumberCharsInRowDescription)
                return false;

            var cols = ColStringFromSeat(boardingPass);
            if (cols.Any(letter => ValidColChars.Contains(letter) == false))
                return false;

            var rows = RowStringFromSeat(boardingPass);
            if (rows.Any(letter => ValidRowChars.Contains(letter) == false))
                return false;

            return true;
        }

        public static int Row(this BoardingPass boardingPass)
        {
            throw new NotImplementedException();
        }

        public static int SeatId(this BoardingPass boardingPass)
        {
            throw new NotImplementedException();
        }
        
        private static string ColStringFromSeat(string boardingPass) => boardingPass.Substring(ColCharStartIndexInSeat, NumberCharsInColDescription);
        private static string RowStringFromSeat(string boardingPass) => boardingPass.Substring(RowCharStartIndexInSeat, NumberCharsInRowDescription);
    }
}