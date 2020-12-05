using System;
using System.Linq;

namespace AdventOfCode.Day5
{
    public static class BoardingPassExtensions
    {
        private static readonly char[] ValidColChars = {'L', 'R'};
        private static readonly char[] ValidRowChars = {'F', 'B'};
        private static readonly int SeatStringNumberCharsForCol = 3;
        private static readonly int SeatStringNumberCharsForRow = 7;
        private static readonly int SeatStringColStartIndex = 7;
        private static readonly int SeatStringRowStartIndex = 0;
        private static int _colIndexMin = 0;
        private static int _colIndexMax = 7;
        private static int _rowIndexMin = 0;
        private static int _rowIndexMax = 127;
        
        public static int Column(this IBoardingPass boardingPass)
        {
            if (boardingPass == null)
                throw new ArgumentNullException(nameof(boardingPass));

            if (boardingPass.IsValid() == false)
                throw new ArgumentException(nameof(boardingPass));

            return CalculateColumnPosition(boardingPass);
        }
        
        public static bool IsValid(this IBoardingPass boardingPass)
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

            if (boardingPass.Length != SeatStringNumberCharsForCol + SeatStringNumberCharsForRow)
                return false;

            var cols = ColStringFromSeat(boardingPass);
            if (cols.Any(letter => ValidColChars.Contains(letter) == false))
                return false;

            var rows = RowStringFromSeat(boardingPass);
            if (rows.Any(letter => ValidRowChars.Contains(letter) == false))
                return false;

            return true;
        }

        public static int Row(this IBoardingPass boardingPass)
        {
            if (boardingPass == null)
                throw new ArgumentNullException(nameof(boardingPass));

            if (boardingPass.IsValid() == false)
                throw new ArgumentException(nameof(boardingPass));

            return CalculateRowPosition(boardingPass);
        }
        
        public static int SeatId(this IBoardingPass boardingPass)
        {
            if (boardingPass == null)
                throw new ArgumentNullException(nameof(boardingPass));

            if (boardingPass.IsValid() == false)
                throw new ArgumentException(nameof(boardingPass));
            
            // (row x 8) + col
            return (Row(boardingPass) * 8) + Column(boardingPass);
        }

        private static string ColStringFromSeat(string boardingPass) =>
            boardingPass.Substring(SeatStringColStartIndex, SeatStringNumberCharsForCol);

        private static string RowStringFromSeat(string boardingPass) =>
            boardingPass.Substring(SeatStringRowStartIndex, SeatStringNumberCharsForRow);
        
        private static int CalculateColumnPosition(IBoardingPass boardingPass)
        {
            var colString = ColStringFromSeat(boardingPass.Seat);
            var colIndexMin = _colIndexMin;
            var colIndexMax = _colIndexMax;
            foreach (var colChar in colString)
            {
                if (colChar == 'R')
                    BinarySpacePartitioning(ref colIndexMin, ref colIndexMax, BinarySpacePartitioningAction.Up);
                
                if (colChar == 'L')
                    BinarySpacePartitioning(ref colIndexMin, ref colIndexMax, BinarySpacePartitioningAction.Down);
            }

            return colIndexMin; // min and max should be equal at this point.
        }
        
        private static int CalculateRowPosition(IBoardingPass boardingPass)
        {
            var rowString = RowStringFromSeat(boardingPass.Seat);
            var rowIndexMin = _rowIndexMin;
            var rowIndexMax = _rowIndexMax;
            foreach (var rowChar in rowString)
            {
                if (rowChar == 'B')
                    BinarySpacePartitioning(ref rowIndexMin, ref rowIndexMax, BinarySpacePartitioningAction.Up);
                
                if (rowChar == 'F')
                    BinarySpacePartitioning(ref rowIndexMin, ref rowIndexMax, BinarySpacePartitioningAction.Down);
            }

            return rowIndexMin; // min and max should be equal at this point.
        }

        private enum BinarySpacePartitioningAction
        {
            Down,
            Up
        }
        
        private static void BinarySpacePartitioning(ref int lowerIndex, ref int upperIndex, BinarySpacePartitioningAction action)
        {
            switch (action)
            {
                case BinarySpacePartitioningAction.Down:
                    upperIndex = upperIndex - ((upperIndex - lowerIndex + 1) / 2);
                    break;
                case BinarySpacePartitioningAction.Up:
                    lowerIndex = lowerIndex + ((upperIndex - lowerIndex + 1) / 2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }
    }
}