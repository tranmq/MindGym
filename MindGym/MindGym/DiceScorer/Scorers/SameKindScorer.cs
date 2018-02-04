using System;
using System.Linq;

namespace MindGym.DiceScorer.Scorers
{
    /// <summary>
    /// X of a kind scorer
    /// </summary>
    public class SameKindScorer : AbstractScorer
    {
        private readonly uint _repeat;

        public SameKindScorer(uint repeat)
        {
            if (repeat > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(repeat), "Use value less than or equal to 5");
            }
            _repeat = repeat;
        }
        public override int Score(int[] inputs)
        {
            if (!(IsValidInput(inputs) && HasThreeOfAKind(inputs)))
                return 0;
            
            return inputs.Sum();
        }

        private bool HasThreeOfAKind(int[] inputs)
        {
            return inputs.GroupBy(x => x).Any(g => g.Count() >= _repeat);
        }
    }
}