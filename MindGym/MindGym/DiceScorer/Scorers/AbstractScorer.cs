﻿using System.Linq;

namespace MindGym.DiceScorer.Scorers
{
    public class AbstractScorer : IScorer
    {
        public virtual int Score(int[] inputs)
        {
            throw new System.NotImplementedException();
        }

        protected static bool IsValidInput(int[] inputs)
        {
            if (inputs == null || inputs.Length != 5)
            {
                return false;
            }

            return inputs.All(item => item >= 1 && item <= 8);
        }

        protected static bool IsScoreInRange(int score)
        {
            return score >= 1 && score <= 8;
        }
    }
}