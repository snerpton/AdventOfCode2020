using AdventOfCode2020.Day8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day8
{
    public class BootConsole
    {
        public int Accumulator { get; private set; }
        public int LineNumber { get; private set; }

        private readonly Instruction[] instructionSet;
        private List<int> lineNumberHistory;

        public BootConsole(Instruction[] instructions)
        {
            if (instructions == null)
                throw new ArgumentNullException();

            instructionSet = instructions;
            lineNumberHistory = new List<int>();

            Accumulator = 0;
            LineNumber = 0;
        }

        public void Run()
        {
            while (lineNumberHistory.Contains(LineNumber) == false && LineNumber < instructionSet.Length)
            {
                lineNumberHistory.Add(LineNumber);
                var thisInstruction = instructionSet[LineNumber];

                switch (thisInstruction.Operation)
                {
                    case Operation.ACC:
                        Accumulator += thisInstruction.Value;
                        LineNumber += 1;
                        break;
                    case Operation.JMP:
                        LineNumber += thisInstruction.Value;
                        break;
                    case Operation.NOP:
                        // No operation
                        LineNumber += 1;
                        break;
                }
            }
        }
    }
}
