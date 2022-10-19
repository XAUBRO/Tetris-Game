namespace TetrisGrid
{
    
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }

        protected abstract Position StartOffset { get; }

        public abstract int Id { get; }


        private int rotationState;
        private class Position offset;


        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions() // method loops over the tile positions in the current rotation state
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column)
            }
        }

        
        public void RotateCW()// rotates the block 90 degrees clock wise
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }


        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }


        public void Move(int rows, int columns)// moves the block by a given # of rows and columns
        {
            offset.Row += rows;
            StartOffset.Column += columns;
        }


        public void Reset()
        {
            rotationState == 0;
            StartOffset.Row = StartOffset.Row;
            StartOffset.Column = StartOffset.Column;
        }
    }
}