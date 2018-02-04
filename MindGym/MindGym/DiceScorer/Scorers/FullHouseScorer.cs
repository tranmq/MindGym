using System.Linq;

namespace MindGym.DiceScorer.Scorers
{
    public class FullHouseScorer : AbstractScorer
    {
        private const int DefaultScore = 25;
        
        public override int Score(int[] inputs)
        {
            if (!(IsValidInput(inputs) && IsFullHouse(inputs)))
            {
                return 0;
            }
            
            return DefaultScore;
        }

        private static bool IsFullHouse(int[] inputs)
        {
            var distinctCountArray = inputs.GroupBy(x => x).Select(g => g.Count()).OrderBy(x => x).ToArray();
            var isFullHouse = distinctCountArray.Length == 2 && distinctCountArray[0] == 2 && distinctCountArray[1] == 3;

            return isFullHouse;
        } 
    }
}