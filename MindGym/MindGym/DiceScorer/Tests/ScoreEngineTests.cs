using MindGym.DiceScorer.Scorers;
using NUnit.Framework;

namespace MindGym.DiceScorer.Tests
{
    [TestFixture]
    public class ScoreEngineTests
    {
        private ScoreEngine _sut;

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
    }
}