using System.Linq;

namespace MindGym.DiceScorer.Scorers
{
    public class NoneOfAKindScorer : AbstractScorer
    {
        private const int DefaultScore = 40;
        
        public override int Score(int[] inputs)
        {
            if (!(IsValidInput(inputs) && AreNoneOfAKind(inputs)))
            {
                return 0;
            }
            
            return DefaultScore;
        }

        private static bool AreNoneOfAKind(int[] inputs)
        {
            return inputs.Distinct().Count() == 5;
        } 
    }
}