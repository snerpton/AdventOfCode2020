using System;

namespace AdventOfCode.Day5
{
    public interface IBoardingPass
    {
        string Seat { get; }
    }

    public class BoardingPass : IBoardingPass
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