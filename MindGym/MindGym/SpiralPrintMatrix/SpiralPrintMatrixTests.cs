using System.Collections.Generic;
using NUnit.Framework;

namespace MindGym.SpiralPrintMatrix
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

        public string OutputResult => string.Join("|", _storage);
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
            _sut.SpiralWalk(null);
            Assert.IsTrue(string.IsNullOrEmpty(_output.OutputResult));
        }

        [Test]
        public void SpiralWalk_WhenInputHasOnlyOneItem_ShouldSucceed()
        {
            var input = new[,] { { 1 } };
            _sut.SpiralWalk(input);
            Assert.AreEqual("1", _output.OutputResult);
        }

        [Test]
        public void SpiralWalk_WhenInputHasOnlyOneRow_ShouldSucceed()
        {
            var input = new[,] { { 1, 2, 3 } };
            _sut.SpiralWalk(input);
            Assert.AreEqual("1|2|3", _output.OutputResult);
        }

        [Test]
        public void SpiralWalk_WhenInputHasOnlyOneColumn_ShouldSucceed()
        {
            var input = new[,]
                        {
                            {1},
                            {2},
                            {3}
                        };
            _sut.SpiralWalk(input);
            Assert.AreEqual("1|2|3", _output.OutputResult);
        }

        [Test]
        public void SpiralWalk_WhenInputIs2x2Matrix_ShouldSucceed()
        {
            var input = new[,]
                        {
                            {1, 2},
                            {4, 3}
                        };
            _sut.SpiralWalk(input);
            Assert.AreEqual("1|2|3|4", _output.OutputResult);
        }

        [Test]
        public void SpiralWalk_WhenInputIs2x3Matrix_ShouldSucceed()
        {
            var input = new[,]
                        {
                            {1, 2, 3},
                            {6, 5, 4}
                        };
            _sut.SpiralWalk(input);
            Assert.AreEqual("1|2|3|4|5|6", _output.OutputResult);
        }

        [Test]
        public void SpiralWalk_WhenInputIs3x2Matrix_ShouldSucceed()
        {
            var input = new[,]
                        {
                            {1, 2},
                            {6, 3},
                            {5, 4}
                        };
            _sut.SpiralWalk(input);
            Assert.AreEqual("1|2|3|4|5|6", _output.OutputResult);
        }

        [Test]
        public void SpiralWalk_WhenInputIs5x5Matrix_ShouldSucceed()
        {
            var input = new[,]
                        {
                            {1,  2,  3,  4,  5},
                            {16, 17, 18, 19, 6},
                            {15, 24, 25, 20, 7},
                            {14, 23, 22, 21, 8},
                            {13, 12, 11, 10, 9},
                        };
            _sut.SpiralWalk(input);
            Assert.AreEqual("1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25", _output.OutputResult);
        }
    }
}