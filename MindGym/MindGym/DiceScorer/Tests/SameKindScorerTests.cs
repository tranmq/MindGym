using System;
using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class SameKindScorerTests
    {
        private SameKindScorer _sut;

        [Test]
        public void Constructor_WhenInitializedWithValueGreaterThanFive_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut = new SameKindScorer(6));
        }
        
        [Test]
        public void Score_WhenInputIsNull_ShouldReturnZero()
        {
            _sut = new SameKindScorer(3);
            var result = _sut.Score(null);
            Assert.IsTrue(result == 0);
        }

        [Test]
        public void Score_WhenThereIsAnInvalidItemInTheInputs_ShouldReturnZero()
        {
            _sut = new SameKindScorer(3);
            var result = _sut.Score(new [] {1, 2, 3, 4, 9});
            Assert.IsTrue(result == 0);
        }
        
        [Test]
        public void Score_WhenTheInputsDoesNotContainExactFiveItems_ShouldReturnZero()
        {
            _sut = new SameKindScorer(3);
            var result = _sut.Score(new int[0]);
            Assert.IsTrue(result == 0);
        }

        [Test, TestCaseSource(typeof(DataToTestThreeOfAKindScorer), nameof(DataToTestThreeOfAKindScorer.TestCases))]
        public int Score_ThreeOfAKindTests(int[] inputs)
        {
            _sut = new SameKindScorer(3);
            return _sut.Score(inputs);
        }
        
        [Test, TestCaseSource(typeof(DataToTestFourOfAKindScorer), nameof(DataToTestFourOfAKindScorer.TestCases))]
        public int Score_FourOfAKindTests(int[] inputs)
        {
            _sut = new SameKindScorer(4);
            return _sut.Score(inputs);
        }
    }
    
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestThreeOfAKindScorer
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {2, 2, 2, 7, 5}).Returns(18);
                yield return new TestCaseData(new[] {4, 4, 4, 4, 8}).Returns(24);
                yield return new TestCaseData(new[] {7, 7, 3, 4, 8}).Returns(0);
                yield return new TestCaseData(new[] {5, 7, 5, 3, 5}).Returns(25);
            }
        }
    }
    
    public class DataToTestFourOfAKindScorer
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {2, 2, 2, 2, 5}).Returns(13);
                yield return new TestCaseData(new[] {4, 4, 4, 4, 8}).Returns(24);
                yield return new TestCaseData(new[] {7, 7, 7, 4, 8}).Returns(0);
                yield return new TestCaseData(new[] {5, 5, 5, 5, 5}).Returns(25);
            }
        }
    }
}