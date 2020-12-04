using AdventOfCode2020.Repositories;

namespace AdventOfCode2020.Models
{
    public class MapLocation
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public PositionType Type { get; set; }
    }
}