using AdventOfCode2020.Day8.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace AdventOfCode2020.Day8.Tests
{
    public class FileParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void ParseLineMethod_Handles_InvalidInput(string invalidInput)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FileParser.ParseLine(invalidInput));
        }

        [Test]
        [TestCase("nop +0", Operation.NOP, 0)]
        [TestCase("acc +0", Operation.ACC, 0)]
        [TestCase("jmp +0", Operation.JMP, 0)]
        [TestCase("acc +1", Operation.ACC, 1)]
        [TestCase("acc -1", Operation.ACC, -1)]
        [TestCase("acc +10", Operation.ACC, 10)]
        [TestCase("acc -10", Operation.ACC, -10)]
        public void ParseLineMethod_Returns_CorrectInstruction(string instructionLine, Operation expectedOperation, int expectedValue)
        {
            var instruction = FileParser.ParseLine(instructionLine);

            Assert.AreEqual(instruction.Operation, expectedOperation);
            Assert.AreEqual(instruction.Value, expectedValue);
        }

        [Test]
        public void ParseMethod_Returns_CorrectInstructionCollection()
        {
            var instructionLines = new List<string>()
            {
                "nop +0",
                "acc +1"
            };
            var expectedInstructions = new List<Instruction>
            {
                new Instruction
                {
                    Operation = Operation.NOP,
                    Value = 0
                },
                new Instruction
                {
                    Operation = Operation.ACC,
                    Value = 1
                }
            };

            var actualInstructions = FileParser.Parse(instructionLines);
            Assert.AreEqual(JsonSerializer.Serialize(actualInstructions), JsonSerializer.Serialize(expectedInstructions));
        }
    }
}