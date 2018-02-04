using System.Linq;

namespace MindGym.DiceScorer.Scorers
{
    public class ChanceScorer : AbstractScorer
    {
        public override int Score(int[] inputs)
        {
            return !IsValidInput(inputs) ? 0 : inputs.Sum();
        }
    }
}