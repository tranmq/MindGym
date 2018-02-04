using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class ChanceScorerTests
    {
        private readonly ChanceScorer _sut = new ChanceScorer();
        
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

        [Test, TestCaseSource(typeof(DataToTestChanceScorer), nameof(DataToTestChanceScorer.TestCases))]
        public int Score_ChanceTests(int[] inputs)
        {
            return _sut.Score(inputs);
        }

        [Test]
        public void MqTest()
        {
            var type = _sut.GetType();
            IScorer scorer = new ChanceScorer();

            type = scorer.GetType();
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestChanceScorer
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 1, 1, 1, 1}).Returns(5);
                yield return new TestCaseData(new[] {4, 4, 4, 4, 4}).Returns(20);
                yield return new TestCaseData(new[] {7, 7, 6, 6, 8}).Returns(34);
                yield return new TestCaseData(new[] {5, 7, 5, 3, 5}).Returns(25);
                yield return new TestCaseData(new[] {1, 2, 3, 4, 5}).Returns(15);
            }
        }
    }
}