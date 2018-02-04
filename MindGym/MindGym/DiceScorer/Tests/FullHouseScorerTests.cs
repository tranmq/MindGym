using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class FullHouseScorerTests
    {
        private readonly FullHouseScorer _sut = new FullHouseScorer();
        
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
        
        [Test, TestCaseSource(typeof(DataToTestFullHouseScorer), nameof(DataToTestFullHouseScorer.TestCases))]
        public int Score_FullHouseTests(int[] inputs)
        {
            return _sut.Score(inputs);
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public class DataToTestFullHouseScorer
    {
        private const int FullHouseScore = 25;
        private const int DefaultScore = 0;
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 1, 2, 2, 2}).Returns(FullHouseScore);
                yield return new TestCaseData(new[] {7, 3, 7, 3, 7}).Returns(FullHouseScore);
                yield return new TestCaseData(new[] {5, 7, 5, 3, 5}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {1, 2, 3, 4, 5}).Returns(DefaultScore);
                yield return new TestCaseData(new[] {2, 2, 3, 3, 5}).Returns(DefaultScore);
            }
        }
    }
}