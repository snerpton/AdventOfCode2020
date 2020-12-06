using System;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day6.Tests
{
    public class GroupResponseExtensionsTests
    {
        public class QuestionsAnsweredWithYesTests
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
        
            [Test]
            [TestCase(new object[]{"acbx", "abcy"}, "abcxy")]
            [TestCase(new object[]{"abc"}, "abc")]
            [TestCase(new object[]{"a", "b", "c"}, "abc")]
            [TestCase(new object[]{"ab", "ac"}, "abc")]
            [TestCase(new object[]{"a", "a", "a", "a"}, "a")]
            [TestCase(new object[]{"b"}, "b")]
            public void Should_DetermineQuestionsAnsweredYesTo_When_ValidGroupResponse(object[] groupResponseObj, string expectedYesTo)
            {
                var groupResponse = groupResponseObj.Select(x => x.ToString());
            
                var sut = new GroupResponse
                {
                    IndividualsResponses = groupResponse.Select(x => new IndividualsResponse(x)).ToList()
                };
        
                Assert.That(sut.QuestionsAnsweredWithYes() == expectedYesTo,
                    $"Actual ({sut.QuestionsAnsweredWithYes()}) not equal to expected ({expectedYesTo}).");
            }
        }
    }

    public class NumberOfQuestionsAnyoneAnsweredYesToTests
    {
        [Test]
        public void Should_ThrowException_When_NullGroupResponse()
        {
            GroupResponse sut = null;

            Assert.Throws<ArgumentNullException>(() => sut.NumberOfQuestionsAnyoneAnsweredYesTo());
        }

        [Test]
        [TestCase(new object[]{"acbx", "abcy"}, 5)]
        [TestCase(new object[]{"abc"}, 3)]
        [TestCase(new object[]{"a", "b", "c"}, 3)]
        [TestCase(new object[]{"ab", "ac"}, 3)]
        [TestCase(new object[]{"a", "a", "a", "a"}, 1)]
        [TestCase(new object[]{"b"}, 1)]
        public void Should_CalculateNumberOfYesToAnswers_When_ValidGroupResponse(object[] groupResponseObj, int expectedNumberOfYesToQuestions)
        {
            var groupResponse = groupResponseObj.Select(x => x.ToString());
            var sut = new GroupResponse
            {
                IndividualsResponses = groupResponse.Select(x => new IndividualsResponse(x)).ToList()
            };
            
            Assert.That(sut.NumberOfQuestionsAnyoneAnsweredYesTo() == expectedNumberOfYesToQuestions);
        }
    }
}