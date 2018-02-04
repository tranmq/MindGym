using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class SmallStraightScorerTests
    {
        private readonly SmallStraightScorer _sut = new SmallStraightScorer();
        
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
        
        [Test, TestCaseSource(typeof(DataToTestSmallStraightScorer), nameof(DataToTestSmallStraightScorer.TestCases))]
        public int Score_SmallStraightTests(int[] inputs)
        {
            return _sut.Score(inputs);
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestSmallStraightScorer
    {
        private const int SmallStraightScore = 30;
        private const int DefaultScore = 0;
        
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 1, 1, 1, 1}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {7, 7, 7, 7, 8}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {5, 7, 5, 3, 5}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {1, 6, 5, 4, 3}).Returns(SmallStraightScore);
                yield return new TestCaseData(new[] {1, 4, 5, 6, 7}).Returns(SmallStraightScore);
                yield return new TestCaseData(new[] {1, 2, 3, 4, 5}).Returns(SmallStraightScore);
                yield return new TestCaseData(new[] {1, 2, 3, 4, 8}).Returns(SmallStraightScore);
                yield return new TestCaseData(new[] {5, 6, 7, 8, 8}).Returns(SmallStraightScore);
                yield return new TestCaseData(new[] {6, 5, 4, 3, 2}).Returns(SmallStraightScore);
            }
        }
    }        
}