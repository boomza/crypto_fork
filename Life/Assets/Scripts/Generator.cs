public class Generator {

    public static void Evolve(Cell[,] cells)
    {
        int rows = cells.GetLength(0);
        int cols = cells.GetLength(1);

        // determine next state from the current
        for (int x = 1; x < rows - 1; x++)      // leave out the borders
            for (int y = 1; y < cols - 1; y++)
                ApplyRule3x3(cells, y, x);      // trt

        // apply next state to the current
        for (int x = 1; x < rows - 1; x++)
            for (int y = 1; y < cols - 1; y++)
                cells[y, x].Evolve();
    }

    /**********************************************************************************
     * Rules:
     Every cell interacts with its 8 nearest neighbors
     Any live cell with two or three neighbors survives   
     Any dead cell with three neigbors awakens
     **********************************************************************************/
    static void ApplyRule3x3(Cell[,] neighbors, int x, int y)
    {
        int count = 0;
        Cell me = neighbors[x, y];

        // count nearest 8 neighbors, and depending on the result
        // set this cell's state to either alive or dead
        for (int row = x - 1; row <= x + 1; row++)
        {
            for(int col = y-1; col <= y+1; col++)
            {
                if (row == x && col == y)    
                    continue;       // skip myself
                if (neighbors[row, col].aliveNow)
                    count++;
            }
        }

        if(me.aliveNow)
        {
            if (count < 2 || count > 3)
                me.aliveNextGen = false;
            else
                me.aliveNextGen = true;     // survives
        }
        else if (count == 3)
            me.aliveNextGen = true;

    }

}
