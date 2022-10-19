namespace TetrisGrid
{
    public class Position // stores a row and a column
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row; 
            Column = column; 
        }
    }
}
	
