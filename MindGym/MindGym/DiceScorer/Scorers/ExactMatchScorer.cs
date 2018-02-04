using System;
using System.Linq;

namespace MindGym.DiceScorer.Scorers
{
    /// <summary>
    /// Score by calculating the sum of items that match its set score.
    /// </summary>
    public class ExactMatchScorer : AbstractScorer
    {
        private readonly int _score;

        public ExactMatchScorer(int score)
        {
            if (!IsScoreInRange(score))
            {
                throw new ArgumentOutOfRangeException(nameof(score), "Should be in the range [1,8].");
            }
            _score = score;
        }
        public override int Score(int[] inputs)
        {
            return !IsValidInput(inputs) ? 0 : inputs.Where(item => item == _score).Sum();
        }
    }
}