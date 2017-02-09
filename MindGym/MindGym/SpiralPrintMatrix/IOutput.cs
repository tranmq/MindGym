namespace MindGym.SpiralPrintMatrix
{
    public interface IOutput
    {
        void Out(string val);
        string OutputResult { get; }
    }
}