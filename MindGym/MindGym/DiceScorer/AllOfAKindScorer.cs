using System.Linq;

namespace MindGym.DiceScorer
{
    public class AllOfAKindScorer : AbstractScorer
    {
        private const int _defaultScore = 50;
        
        public override int Score(int[] inputs)
        {
            if (!(IsValidInput(inputs) && AreAllOfAKind(inputs)))
            {
                return 0;
            }
            
            return _defaultScore;
        }

        private static bool AreAllOfAKind(int[] inputs)
        {
            return inputs.Distinct().Count() == 1;
        }
    }
}