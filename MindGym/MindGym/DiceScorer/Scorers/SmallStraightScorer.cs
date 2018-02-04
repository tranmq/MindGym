namespace MindGym.DiceScorer.Scorers
{
    public class SmallStraightScorer : AbstractScorer
    {
        private const int DefaultScore = 30;

        public override int Score(int[] inputs)
        {
            if (!(IsValidInput(inputs) && IsSmallStraight(inputs)))
            {
                return 0;
            }

            return DefaultScore;
        }

        private static bool IsSmallStraight(int[] inputs)
        {
            return AreArrayItemsInSequence(inputs, 0, inputs.Length - 2) ||
                   AreArrayItemsInSequence(inputs, 1, inputs.Length - 1);
        }

        /// <summary>
        /// Determines if the elements from the start index to the end index are in sequence.
        /// </summary>
        /// <param name="inputs">the input array</param>
        /// <param name="start">0 based starting index to start the test</param>
        /// <param name="end">0 based ending index to stop the test</param>
        /// <returns></returns>
        private static bool AreArrayItemsInSequence(int[] inputs, int start, int end)
        {
            if (start == end)
            {
                return true;
            }

            if (inputs[start] == inputs[start + 1])
            {
                return false;
            }

            var isAscending = inputs[start] < inputs[start + 1];

            for (int i = start; i < end; i++)
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