using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Models;
using AdventOfCode2020.Repositories;

namespace AdventOfCode2020.Services
{
    public class XmasTreeMapService
    {
        private readonly IEnumerable<MapLocation> _xmasTreeMap;
        private readonly int _singleMoveX;
        private readonly int _singleMoveY;
        
        public XmasTreeMapService(IEnumerable<MapLocation> xmasTreeMap , int singleMoveX, int singleMoveY)
        {
            if (xmasTreeMap == null)
                throw new ArgumentNullException(nameof(xmasTreeMap));

            if (xmasTreeMap.Any() == false)
                throw new ArgumentOutOfRangeException(nameof(xmasTreeMap));

            _xmasTreeMap = xmasTreeMap;

            if (singleMoveX < 0)
                throw new ArgumentOutOfRangeException(nameof(singleMoveX));

            _singleMoveX = singleMoveX;

            if (singleMoveY < 0)
                throw new ArgumentOutOfRangeException(nameof(singleMoveY));

            _singleMoveY = singleMoveY;
        }

        public int CountTrees()
        {
            var currentPositionX = 0;
            var currentPositionY = 0;
            var maxIndexX = _xmasTreeMap.Max(x => x.XPosition);
            var maxIndexY = _xmasTreeMap.Max(x => x.YPosition);
            var treesEncountered = 0;

            while (currentPositionY <= maxIndexY)
            {
                var newPositionX = currentPositionX + _singleMoveX > maxIndexX
                    ? currentPositionX + _singleMoveX - maxIndexX -1
                    : currentPositionX + _singleMoveX;
                var newPositionY = currentPositionY + _singleMoveY;

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