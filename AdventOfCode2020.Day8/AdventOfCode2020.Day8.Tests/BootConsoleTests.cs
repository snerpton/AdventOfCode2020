using AdventOfCode2020.Day8.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AdventOfCode2020.Day8.Tests
{
    public class BootConsoleTests
    {
        [Test]
        public void RunMethod_Sets_Accumulator_Correctly()
        {
            var instructionStrings = new List<string>()
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };
            var instructions = FileParser.Parse(instructionStrings);

            var bootConsole = new BootConsole(instructions.ToArray());
            bootConsole.Run();

            Assert.AreEqual(1, bootConsole.LineNumber);
            Assert.AreEqual(5, bootConsole.Accumulator);
        }
    }
}
