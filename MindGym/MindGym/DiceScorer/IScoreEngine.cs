namespace MindGym.DiceScorer
{
    public interface IScoreEngine
    {
        void AddScorer(IScorer scorer);
    }
}