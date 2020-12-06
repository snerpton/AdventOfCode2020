using System;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day6.Tests
{
    public class GroupResponseExtensionsTests
    {
        [Test]
        public void Should_ThrowException_When_NullGroupResponse()
        {
            GroupResponse sut = null;

            Assert.Throws<ArgumentNullException>(() => sut.QuestionsAnsweredWithYes());
        }

        [Test]
        public void Should_ReturnEmptyCollection_When_GroupResponseIndividualsResponsesNotPopulated()
        {
            var sut = new GroupResponse();
            
            Assert.That(sut.QuestionsAnsweredWithYes().Length == 0);
        }
    }
}