using System;
using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class ExactMatchScorerTests
    {
        private ExactMatchScorer _sut;

        [Test]
        public void Constructor_WhenInitializedWithValueLessThanOne_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut = new ExactMatchScorer(0));
        }

        [Test]
        public void Constructor_WhenInitializedWithValueGreaterThanEight_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut = new ExactMatchScorer(9));
        }

        [Test]
        public void Score_WhenInputIsNull_ShouldReturnZero()
        {
            _sut = new ExactMatchScorer(1);
            var result = _sut.Score(null);
            Assert.IsTrue(result == 0);
        }

        [Test]
        public void Score_WhenTheInputsDoesNotContainExactFiveItems_ShouldReturnZero()
        {
            _sut = new ExactMatchScorer(2);
            var result = _sut.Score(new int[0]);
            Assert.IsTrue(result == 0);
        }

        [Test]
        public void Score_WhenThereIsAnInvalidItemInTheInputs_ShouldReturnZero()
        {
            _sut = new ExactMatchScorer(3);
            var result = _sut.Score(new [] {1, 2, 3, 4, 9});
            Assert.IsTrue(result == 0);
        }
        
        [Test, TestCaseSource(typeof(DataToTestOnesScorer), nameof(DataToTestOnesScorer.TestCases))]
        public int Score_WhenTheScorerIsOne_ShouldScoreCorrectly(int[] inputs)
        {
            _sut = new ExactMatchScorer(1);
            return _sut.Score(inputs);
        }
        
        [Test, TestCaseSource(typeof(DataToTestTwoScorer), nameof(DataToTestTwoScorer.TestCases))]
        public int Score_WhenTheScorerIsTwo_ShouldScoreCorrectly(int[] inputs)
        {
            _sut = new ExactMatchScorer(2);
            return _sut.Score(inputs);
        }
        
        // And continue with 3, 4, 5, 6, 7, 8
    }
    

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestOnesScorer
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 1, 1, 1, 1}).Returns(5);
                yield return new TestCaseData(new[] {1, 1, 1, 4, 8}).Returns(3);
                yield return new TestCaseData(new[] {2, 5, 3, 4, 8}).Returns(0);
            }
        }
    }
    
    public class DataToTestTwoScorer
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {2, 2, 2, 2, 2}).Returns(10);
                yield return new TestCaseData(new[] {2, 2, 2, 4, 8}).Returns(6);
                yield return new TestCaseData(new[] {7, 5, 3, 4, 8}).Returns(0);
            }
        }
    }
}