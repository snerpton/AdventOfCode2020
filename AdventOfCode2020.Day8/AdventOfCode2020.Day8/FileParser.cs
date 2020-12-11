using AdventOfCode2020.Day8.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Day8
{
    public static class FileParser
    {
        public static IEnumerable<string> Read(string filePath)
        {
            return File.ReadLines(filePath);
        }

        public static IEnumerable<Instruction> Parse(IEnumerable<string> instructionLines)
        {
            return instructionLines.Select(x => ParseLine(x));
        }

        public static Instruction ParseLine(string instructionLine)
        {
            if (string.IsNullOrWhiteSpace(instructionLine))
                throw new ArgumentOutOfRangeException(nameof(instructionLine));

            var instructionParts = instructionLine.Split(' ');
            var operation = instructionParts[0] switch {
                "acc" => Operation.ACC,
                "jmp" => Operation.JMP,
                "nop" => Operation.NOP,
                _ => throw new ArgumentOutOfRangeException(nameof(instructionLine))
            };

            var valueString = instructionParts[1].Replace("+", string.Empty);
            if (!int.TryParse(valueString, out var value))
                throw new ArgumentOutOfRangeException(nameof(instructionLine));

            return new Instruction
            {
                Operation = operation,
                Value = value
            };
        }
    }
}