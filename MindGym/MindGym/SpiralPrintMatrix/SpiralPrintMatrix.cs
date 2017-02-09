namespace MindGym.SpiralPrintMatrix
{
    public class SpiralPrintMatrix
    {
        private readonly IOutput _output;
        private Direction[] _spirals = { Direction.East, Direction.South, Direction.West, Direction.North };

        public SpiralPrintMatrix(IOutput output)
        {
            _output = output;
        }

        public void SpiralWalk(int[,] input)
        {
            if (input == null)
                return;

            var left = 0;
            var top = 0;
            var right = input.GetLength(1) - 1;
            var bottom = input.GetLength(0) - 1;

            while (true)
            {
                foreach (var direction in _spirals)
                {
                    if ((left > right) || (top > bottom))
                        return;
                    StraightWalk(input, direction, ref left, ref right, ref top, ref bottom);
                }
            }
        }

        private void StraightWalk(int[,] input, Direction direction, ref int left, ref int right, ref int top, ref int bottom)
        {
            switch (direction)
            {
                case Direction.East:
                    for (int i = left; i <= right; i++)
                    {
                        _output.Out(input[top, i].ToString());
                    }
                    top++;
                    break;
                case Direction.South:
                    for (int i = top; i <= bottom; i++)
                    {
                        _output.Out(input[i, right].ToString());
                    }
                    right--;
                    break;
                case Direction.West:
                    for (int i = right; i >= left; i--)
                    {
                        _output.Out(input[bottom, i].ToString());
                    }
                    bottom--;
                    break;
                case Direction.North:
                    for (int i = bottom; i >= top; i--)
                    {
                        _output.Out(input[i, left].ToString());
                    }
                    left++;
                    break;
            }
        }

        private enum Direction
        {
            East,
            West,
            North,
            South
        }
    }
}