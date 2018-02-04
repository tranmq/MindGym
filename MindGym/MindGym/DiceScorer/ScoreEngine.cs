using System.Collections.Generic;
using System.Linq;
using MindGym.DiceScorer.Scorers;

namespace MindGym.DiceScorer
{
    public class ScoreEngine : AbstractScorer, IScoreEngine
    {
        private readonly List<IScorer> _scorers;

        public ScoreEngine(bool initWithAllScorers)
        {
            _scorers = new List<IScorer>(20);
            if (!initWithAllScorers)
            {
                return;
            }
            InitScorers();
        }

        private void InitScorers()
        {
            InitAllExactMatchScorers();
            InitThreeAndFourOfAKindScorers();
            _scorers.Add(new AllOfAKindScorer());
            _scorers.Add(new NoneOfAKindScorer());
            _scorers.Add(new FullHouseScorer());
            _scorers.Add(new SmallStraightScorer());
            _scorers.Add(new LargeStraightScorer());
            _scorers.Add(new ChanceScorer());
        }

        private void InitThreeAndFourOfAKindScorers()
        {
            _scorers.Add(new SameKindScorer(3));
            _scorers.Add(new SameKindScorer(4));
        }

        private void InitAllExactMatchScorers()
        {
            for (var i = 1; i <= 8; i++)
            {
                _scorers.Add(new ExactMatchScorer(i));
            }
        }


        public override int Score(int[] inputs)
        {
            if (_scorers.Count == 0)
            {
                return 0;
            }
            var maxScore = _scorers.Max(x => x.Score(inputs));
            return maxScore;
        }
        
        public void AddScorer(IScorer scorer)
        {
            if (scorer == null)
            {
                return;
            }
            _scorers.Add(scorer);
        }
    }
}