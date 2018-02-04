using System.Linq;

namespace MindGym.DiceScorer.Scorers
{
    public class AllOfAKindScorer : AbstractScorer
    {
        private const int DefaultScore = 50;
        
        public override int Score(int[] inputs)
        {
            if (!(IsValidInput(inputs) && AreAllOfAKind(inputs)))
            {
                return 0;
            }
            
            return DefaultScore;
        }

        private static bool AreAllOfAKind(int[] inputs)
        {
            return inputs.Distinct().Count() == 1;
        }
    }
}