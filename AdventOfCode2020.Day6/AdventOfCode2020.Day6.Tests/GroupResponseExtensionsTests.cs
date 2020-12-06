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
        
        // [Test]
        // [TestCase(new object[]{"ABC"}, "ABC")]
        // [TestCase(new object[]{"ABCX", "ABCY"}, "ABCXY")]
        //
        // [TestCase(new object[]{"ABCX", "ABCY"}, "ABCXY")]
        // [TestCase(new object[]{"ABCX", "ABCY"}, "ABCXY")]
        // [TestCase(new object[]{"ABCX", "ABCY"}, "ABCXY")]
        // [TestCase(new object[]{"ABCX", "ABCY"}, "ABCXY")]
        // [TestCase(new object[]{"ABCX", "ABCY"}, "ABCXY")]
        // public void Should_DetermineQuestionsAnsweredYesTo_When_ValidGroupResponse(object[] groupResponseObj, string expectedYes)
        // {
        //     var groupResponse = groupResponseObj.Select(x => x.ToString());
        //     
        //     var sut = new GroupResponse
        //     {
        //         IndividualsResponses = groupResponse.Select(x => new IndividualsResponse(x))
        //     };
        //     
        //     Assert.That(sut.QuestionsAnsweredWithYes().Length == 0);
        // }
    }
}