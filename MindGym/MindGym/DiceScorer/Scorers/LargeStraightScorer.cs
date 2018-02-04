namespace MindGym.DiceScorer.Scorers
{
    public class LargeStraightScorer : AbstractScorer
    {
        private const int DefaultScore = 40;

        public override int Score(int[] inputs)
        {
            if (!(IsValidInput(inputs) && IsLargeStraight(inputs)))
            {
                return 0;
            }

            return DefaultScore;
        }

        private static bool IsLargeStraight(int[] inputs)
        {
            if (inputs[0] == inputs[1])
            {
                return false;
            }

            var isAscending = inputs[0] < inputs[1];
            
            for (int i = 0; i < inputs.Length - 1; i++)
            {
                if (isAscending)
                {
                    if (inputs[i] != inputs[i + 1] - 1)
                    {
                        return false;
                    }
                }
                else
                {
                    if (inputs[i] != inputs[i + 1] + 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}