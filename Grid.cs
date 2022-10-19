namespace TetrisGrid
{

	public class Grid // hold a 2 dimensional rectangular array
	{			      // 1st dim = row 2nd dim = column	
					  // also properties for the # of rows and columns				
		private readonly int[,] grid;

		public int Rows { get; }

		public int Columns { get; }

		public int this[int r, int c] // r==row c== column
		{
			get => grid[r, c];       // this is an indexer to provide easy access to the array
            set => grid[r, c] = value; // with this in place we can use indexing directly on a Grid object

        }
		
		public Grid(int rows, int columns) // takes the number of rows and columns as parameters
        {                                  // this class can now be used on any grid size
            Rows = rows;
			Columns = columns;
			grid = new int[rows, columns];								// we save the number of rows and columns and initialize the array
		}

		public bool IsInside(int r, int c) //  checks if row and column is in the grid
		{
			return r >= 0 && r < Rows && c >= 0 && c < Columns; //to be inside the grid the row must be greater than or equal to 0 and less than the number of rows
		}														// same for columns

		public bool IsEmpty(int r, int c) //method to check if a given cell is empty 
		{
			return IsInside(r, c) && grid[r, c] == 0; // must be inside the grid and the value must be 0
		}

		public bool IsRowFull(int r) // checks if the entire row is full
		{
			for (int c = 0; c < Columns; c++) // FIGURE OUT
			{
				if (grid[r, c] == 0)
				{
					return false;
				}

			}

			return true;
		}

		public bool	IsRowEmpty(int r)         // checks if a row is empty
		{
			for (int c = 0; c < Columns; c++)
			{
				if (grid[r, c] != 0)
				{
					return false;
				}

			}

			return true;
		}

		private void ClearRow(int r) // starting at the bottom row ClearRow= 0 , it then incriments up the rows 1,2,3,4 (stroing this value in ClearRow) clearing any rows that are full// once all full rows have been removed the ClearRow method will move down the number of spaces it has been assigned
		{
			for (int c = 0; c < Columns; c++)
			{
				grid[r, c] = 0;	
			}

		}

		private void MoveRowDown(int r, int numRows) // new var num rows
		{
			for (int c= 0; c < Columns; c++)
			{
				grid[r + numRows, c] = grid[r, c];
				grid[r, c] = 0;
			}
		}

		public int ClearFilledRows()
		{
			int cleared = 0; // starts at 0 bottom from top

			for (int r = Rows-1; r >= 0; r--)
			{
				if (IsRowFull(r))
				{
					ClearRow(r);
					cleared++;
				}
				else if (cleared > 0)
				{
					MoveRowDown(r, cleared);
				}
			}

			return cleared;
		}
    } 
}
















