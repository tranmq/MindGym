using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Interview.SpiralPrintMatrix
{
    internal class OutToList : IOutput
    {
        private readonly List<string> _storage = new List<string>();
        public void Out(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return;
            }
            _storage.Add(val);
        }

        public string OutputResult
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var item in _storage)
                {
                    sb.Append(item);
                }
                return sb.ToString();
            }
        }
    }

    [TestFixture]
    public class SpiralPrintMatrixTests
    {
        private IOutput _output;
        private SpiralPrintMatrix _sut;

        [SetUp]
        public void Setup()
        {
            _output = new OutToList();
            _sut = new SpiralPrintMatrix(_output);
        }

        [Test]
        public void SpiralWalk_WhenInputIsNull_ShouldNotOutputAnything()
        {
            int[,] input = null;
            _sut.SpiralWalk(input);
            Assert.IsTrue(string.IsNullOrEmpty(_output.OutputResult));
        }

    }
}