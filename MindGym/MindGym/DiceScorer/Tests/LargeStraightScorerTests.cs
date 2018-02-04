using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class LargeStraightScorerTests
    {
        private readonly LargeStraightScorer _sut = new LargeStraightScorer();
        
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
        
        [Test, TestCaseSource(typeof(DataToTestLargeStraightScorer), nameof(DataToTestLargeStraightScorer.TestCases))]
        public int Score_SmallStraightTests(int[] inputs)
        {
            return _sut.Score(inputs);
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestLargeStraightScorer
    {
        private const int LargeStraightScore = 40;
        private const int DefaultScore = 0;
        
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {2, 3, 4, 5, 1}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {7, 3, 4, 5, 6}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {5, 7, 5, 3, 5}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {1, 2, 3, 4, 5}).Returns(LargeStraightScore);
                yield return new TestCaseData(new[] {3, 4, 5, 6, 7}).Returns(LargeStraightScore);
                yield return new TestCaseData(new[] {8, 7, 6, 5, 4}).Returns(LargeStraightScore);
                yield return new TestCaseData(new[] {5, 4, 3, 2, 1}).Returns(LargeStraightScore);
            }
        }
    }
}