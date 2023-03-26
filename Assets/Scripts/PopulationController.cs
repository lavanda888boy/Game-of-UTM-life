using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationController : MonoBehaviour
{
    public void PopulationControl(Grid grid)
    {
        // Rules
        // 1. Any live cell with fewer than two live neighbors dies, as if caused by underpopulation.
        // 2. Any live cell with two or three live neighbors lives on to the next generation.
        // 3. Any live cell with more than three live neighbors dies, as if by overpopulation.
        // 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
        int height = grid.height;
        int width = grid.width;
        Cell[,] cells = grid.GetCells();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (cells[x, y].isAlive)
                {
                    if (cells[x, y].numNeighbors != 2 && cells[x, y].numNeighbors != 3)
                    {
                        cells[x, y].SetAlive(false);
                    }
                }
                else
                {
                    if (cells[x, y].numNeighbors == 3)
                    {
                        cells[x, y].SetAlive(true);
                    }
                }
            }
        }
    }
}
