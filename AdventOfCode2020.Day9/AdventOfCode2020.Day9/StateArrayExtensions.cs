using System;
using AdventOfCode2020.Day9.Models;

namespace AdventOfCode2020.Day9
{
    public static class StateArrayExtensions
    {
        public static int CalculateNumberOfActiveStateCubesAfterIterating(this State[,,] stateGrid, int numberOfIterations)
        {
            if (stateGrid == null)
                throw new ArgumentNullException(nameof(stateGrid));
            
            if (numberOfIterations < 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfIterations));

            var currentStateGrid = stateGrid.Clone() as State[,,];
            var iteratedStateGrid = stateGrid.Clone() as State[,,];
            
            for (var iteration = 0; iteration < numberOfIterations; iteration++)
            {
                iteratedStateGrid = currentStateGrid.Clone() as State[,,];
                iteratedStateGrid.Iterate(currentStateGrid);
                currentStateGrid = iteratedStateGrid.Clone() as State[,,];
            }

            var numberOfActive = iteratedStateGrid.NumberActiveInRange(
                0, iteratedStateGrid.GetLength(0),
                0, iteratedStateGrid.GetLength(1),
                0, iteratedStateGrid.GetLength(2));
            
            return numberOfActive;
        }

        public static void Iterate(this State[,,] stateGridToIterate, State[,,] currentStateGrid)
        {
            const int interactionLength = 1;
            
            for (var x = 0; x < stateGridToIterate.GetLength(0); x++)
            {
                for (var y = 0; y < stateGridToIterate.GetLength(1); y++)
                {
                    for (var z = 0; z < stateGridToIterate.GetLength(2); z++)
                    {
                        var xMin = GetMin(x, interactionLength);
                        var xMax = GetMax(x, interactionLength, stateGridToIterate.GetLength(0));
                        
                        var yMin = GetMin(y, interactionLength);
                        var yMax = GetMax(y, interactionLength, stateGridToIterate.GetLength(1));
                        
                        var zMin = GetMin(z, interactionLength);
                        var zMax = GetMax(z, interactionLength, stateGridToIterate.GetLength(2));


                        switch (currentStateGrid[x, y, z])
                        {
                            case State.Active:
                            {
                                var numberActiveInRange =
                                    currentStateGrid.NumberActiveInRange(xMin, xMax, yMin, yMax, zMin, zMax) - 1;

                                if (numberActiveInRange == 2 || numberActiveInRange == 3)
                                    stateGridToIterate[x, y, z] = State.Active;
                                else
                                    stateGridToIterate[x, y, z] = State.Inactive;

                                break;
                            }
                            case State.Inactive:
                            {
                                var numberActiveInRange =
                                    currentStateGrid.NumberActiveInRange(xMin, xMax, yMin, yMax, zMin, zMax);

                                if (numberActiveInRange == 3)
                                    stateGridToIterate[x, y, z] = State.Active;
                                else
                                    stateGridToIterate[x, y, z] = State.Inactive;

                                break;
                            }
                        }
                    }
                }
            }
        }

        private static int GetMin(int currentPosition, int interactionLength) =>
            currentPosition - interactionLength < 0
                ? 0
                : currentPosition - interactionLength;

        private static int GetMax(int currentPosition, int interactionLength, int maxPosition) =>
            currentPosition + interactionLength > maxPosition
                ? maxPosition
                : currentPosition + interactionLength;

        private static int NumberActiveInRange(this State[,,] stateGrid, int xMin, int xMax, int yMin, int yMax,
            int zMin, int zMax)
        {
            var numberActive = 0;

            for (var x = 0; x < stateGrid.GetLength(0); x++)
            {
                for (var y = 0; y < stateGrid.GetLength(1); y++)
                {
                    for (var z = 0; z < stateGrid.GetLength(2); z++)
                    {
                        if (x >= xMin && x <= xMax && y >=yMin && y <= yMax && z >= zMin && z <= zMax)
                        {
                            if (stateGrid[x, y, z] == State.Active)
                                numberActive++;
                        }
                    } 
                }
            }
            
            return numberActive;
        }
    }
}