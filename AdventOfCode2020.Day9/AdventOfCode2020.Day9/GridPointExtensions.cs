using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day9.Models;

namespace AdventOfCode2020.Day9
{
    public static class GridPointExtensions
    {
        public static State[,,] ToInitialGridFromGridPoints(this IEnumerable<GridPoint> gridPoints)
        {
            if (gridPoints == null)
                throw new ArgumentNullException(nameof(gridPoints));

            if (gridPoints.Any() == false)
                throw new ArgumentOutOfRangeException(nameof(gridPoints));

            var minXIndex = gridPoints.Min(gp => gp.X);
            var maxXIndex = gridPoints.Max(gp => gp.X);
            var xWidth = maxXIndex - minXIndex + 1;

            var minYIndex = gridPoints.Min(gp => gp.Y);
            var maxYIndex = gridPoints.Max(gp => gp.Y);
            var yWidth = maxYIndex - minYIndex + 1;

            var minZIndex = gridPoints.Min(gp => gp.Z);
            var maxZIndex = gridPoints.Max(gp => gp.Z);
            var zWidth = maxZIndex - minZIndex + 1;

            var gridPointRtn = new State[xWidth, yWidth, zWidth];

            foreach (var gridPoint in gridPoints)
                gridPointRtn[gridPoint.X, gridPoint.Y, gridPoint.Z] = gridPoint.State;

            // Sanity check...
            if (xWidth != gridPointRtn.GetLength(0))
                throw new Exception("Error creating initial grid: width");

            if (yWidth != gridPointRtn.GetLength(1))
                throw new Exception("Error creating initial grid: height");

            if (zWidth != gridPointRtn.GetLength(2))
                throw new Exception("Error creating initial grid: depth");

            return gridPointRtn;
        }

        public static State[,,] ToProblemGridFromGridPoints(this IEnumerable<GridPoint> gridPoints,
            int numberOfIterations)
        {
            var initialGrid = gridPoints.ToInitialGridFromGridPoints();

            // Assumption... each iteration adds 2 cells to each dimension
            var cellAdditionPerDimensionPerIteration = 2;
            var initialXWidth = initialGrid.GetLength(0);
            var initialYHeight = initialGrid.GetLength(1);
            var initialZDepth = initialGrid.GetLength(2);

            var gridPointRtn = new State[
                initialXWidth + cellAdditionPerDimensionPerIteration * numberOfIterations,
                initialYHeight + cellAdditionPerDimensionPerIteration * numberOfIterations,
                initialZDepth + cellAdditionPerDimensionPerIteration * numberOfIterations];

            for (var x = 0; x < gridPointRtn.GetLength(0); x++)
            {
                for (var y = 0; y < gridPointRtn.GetLength(1); y++)
                {
                    for (var z = 0; z < gridPointRtn.GetLength(2); z++)
                    {
                        var offset = cellAdditionPerDimensionPerIteration * numberOfIterations / 2; // divide by two as cells added to both sides
                        
                        if (x >= offset
                            && y >= offset
                            && z >= offset
                            && x < initialXWidth + offset
                            && y < initialYHeight + offset
                            && z < initialZDepth + offset)
                        {
                            gridPointRtn[x, y, z] = initialGrid[x-offset, y-offset, z-offset];
                        }
                        else
                        {
                            gridPointRtn[x, y, z] = State.Inactive;
                        }
                    }
                }
            }

            return gridPointRtn;
        }
    }
}