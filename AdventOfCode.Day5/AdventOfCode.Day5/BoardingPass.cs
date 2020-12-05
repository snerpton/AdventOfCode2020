using System;

namespace AdventOfCode.Day5
{
    public class BoardingPass
    {
        public BoardingPass(string seat)
        {
            if (string.IsNullOrWhiteSpace(seat))
                throw new ArgumentNullException(nameof(seat));

            this.Seat = seat;
        }
        
        public string Seat { get; private set; }
    }
}