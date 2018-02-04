using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class NoneOfAKindScorerTests
    {
        private readonly NoneOfAKindScorer _sut = new NoneOfAKindScorer();
        
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
        
        [Test, TestCaseSource(typeof(DataToTestNoneOfAKindScorer), nameof(DataToTestNoneOfAKindScorer.TestCases))]
        public int Score_NoneOfAKindTests(int[] inputs)
        {
            return _sut.Score(inputs);
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestNoneOfAKindScorer
    {
        private const int NoneOfAKindScore = 40;
        private const int DefaultScore = 0;
        
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 1, 1, 1, 1}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {7, 7, 7, 7, 8}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {5, 7, 5, 3, 5}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {1, 2, 3, 4, 5}).Returns(NoneOfAKindScore);
                yield return new TestCaseData(new[] {3, 2, 1, 4, 5}).Returns(NoneOfAKindScore);
                yield return new TestCaseData(new[] {3, 5, 1, 4, 2}).Returns(NoneOfAKindScore);
            }
        }
    }        
}