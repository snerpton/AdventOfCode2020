using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{
    public class XmasTreeMapService : IXmasTreeMapService
    {
        private readonly IEnumerable<MapLocation> _xmasTreeMap;

        public XmasTreeMapService(IEnumerable<MapLocation> xmasTreeMap)
        {
            if (xmasTreeMap == null)
                throw new ArgumentNullException(nameof(xmasTreeMap));

            if (xmasTreeMap.Any() == false)
                throw new ArgumentOutOfRangeException(nameof(xmasTreeMap));

            _xmasTreeMap = xmasTreeMap;
        }

        public int CountTrees(int singleMoveX, int singleMoveY)
        {
            if (singleMoveX < 0)
                throw new ArgumentOutOfRangeException(nameof(singleMoveX));

            if (singleMoveY < 0)
                throw new ArgumentOutOfRangeException(nameof(singleMoveY));

            var currentPositionX = 0;
            var currentPositionY = 0;
            var maxIndexX = _xmasTreeMap.Max(x => x.XPosition);
            var maxIndexY = _xmasTreeMap.Max(x => x.YPosition);
            var treesEncountered = 0;

            while (currentPositionY <= maxIndexY)
            {
                var newPositionX = currentPositionX + singleMoveX > maxIndexX
                    ? currentPositionX + singleMoveX - maxIndexX -1
                    : currentPositionX + singleMoveX;
                var newPositionY = currentPositionY + singleMoveY;

                currentPositionX = newPositionX;
                currentPositionY = newPositionY;
                
                if (currentPositionY > maxIndexY)
                    break;
                
                var newPosition =
                    _xmasTreeMap.Single(l => l.XPosition == newPositionX && l.YPosition == newPositionY);
                treesEncountered = newPosition.Type == PositionType.Tree ? treesEncountered + 1 : treesEncountered;
            }

            return treesEncountered;
        }
    }
}