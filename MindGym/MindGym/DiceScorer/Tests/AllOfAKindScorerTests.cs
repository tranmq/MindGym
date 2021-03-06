﻿using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class AllOfAKindScorerTests
    {
        private readonly AllOfAKindScorer _sut = new AllOfAKindScorer();

        [Test]
        public void Score_WhenInputIsNull_ShouldReturnZero()
        {
            var result = _sut.Score(null);
            Assert.IsTrue(result == 0);
        }

        [Test]
        public void Score_WhenTheInputsDoesNotContainExactFiveItems_ShouldReturnZero()
        {
            var result = _sut.Score(new int[0]);
            Assert.IsTrue(result == 0);
        }

        [Test]
        public void Score_WhenThereIsAnInvalidItemInTheInputs_ShouldReturnZero()
        {
            var result = _sut.Score(new [] {1, 2, 3, 4, 9});
            Assert.IsTrue(result == 0);
        }

        [Test, TestCaseSource(typeof(DataToTestAllOfAKindScorer), nameof(DataToTestAllOfAKindScorer.TestCases))]
        public int Score_AllOfAKindTests(int[] inputs)
        {
            return _sut.Score(inputs);
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestAllOfAKindScorer
    {
        private const int AllOfAKindScore = 50;
        private const int DefaultScore = 0;
        
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 1, 1, 1, 1}).Returns(AllOfAKindScore);
                yield return new TestCaseData(new[] {4, 4, 4, 4, 4}).Returns(AllOfAKindScore);
                yield return new TestCaseData(new[] {7, 7, 7, 7, 8}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {5, 7, 5, 3, 5}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {1, 2, 3, 4, 5}).Returns(DefaultScore);
            }
        }
    }
}