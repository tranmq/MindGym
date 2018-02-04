using System.Collections;
using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class ScoreEngineTests
    {
        private ScoreEngine _sut = new ScoreEngine(true);

        [Test]
        public void Score_WhenNotInitializedWithAnyScorers_ShouldReturnZero()
        {
            _sut = new ScoreEngine(false);
            var inputs = new[] {1, 2, 3, 4, 5};
            var score = _sut.Score(inputs);
            Assert.IsTrue(score == 0);
        }

        [Test]
        public void Score_WhenInitializedWithOnlyOnesScorer_ShouldReturnCorrectScore()
        {
            _sut = new ScoreEngine(false);
            _sut.AddScorer(new ExactMatchScorer(1));
            var inputs = new[] {1, 5, 5, 5, 5};
            var score = _sut.Score(inputs);
            Assert.AreEqual(1, score);
        }
        
        [Test]
        public void Score_WhenInitializedWithTwosAndThreeOfAKindScorers_ShouldReturnCorrectScore()
        {
            _sut = new ScoreEngine(false);
            _sut.AddScorer(new ExactMatchScorer(2));
            _sut.AddScorer(new SameKindScorer(3));
            var inputs = new[] {1, 1, 1, 1, 6};
            var score = _sut.Score(inputs);
            Assert.AreEqual(10, score);
        }

        [Test, TestCaseSource(typeof(DataToTestScoreEngine), nameof(DataToTestScoreEngine.TestCases))]
        public int Score_WhenInitializedWithAllScorers_ShouldReturnCorrectScore(int[] inputs)
        {
            return _sut.Score(inputs);
        }
    }
        
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Test case data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DataToTestScoreEngine
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 1, 1, 4, 8}).Returns(15); // test case from the homework
                yield return new TestCaseData(new[] {8, 8, 8, 8, 8}).Returns(50);
                yield return new TestCaseData(new[] {7, 6, 5, 4, 3}).Returns(40);
            }
        }
    }
}