using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationController : MonoBehaviour
{
    public void GeneralRules(Grid grid)
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

    public void ExplosionRules(Grid grid)
    {
        // Rules
        // Same as general, besides the fact that if a cell has more than
        // 3 neighbors, it explodes into four new cells, one in each cardinal direction.
        int height = grid.height;
        int width = grid.width;
        Cell[,] cells = grid.GetCells();
        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                if (cells[x, y].isAlive)
                {
                    if (cells[x, y].numNeighbors > 3) // change from >= to >
                    {
                        // save the cell that will explode
                        Cell explodingCell = cells[x, y];

                        // set the four neighboring cells to alive
                        cells[x + 1, y].SetAlive(true);
                        cells[x - 1, y].SetAlive(true);
                        cells[x - 1, y].color = "black";
                        cells[x, y + 1].SetAlive(true);
                        cells[x, y + 1].color = "black";
                        cells[x, y - 1].SetAlive(true);
                        cells[x, y - 1].color = "black";

                        // set the exploding cell to dead
                        explodingCell.SetAlive(false);
                        explodingCell.color = "white";
                    }
                }
            }
        }
    }

    public void ToxicRules(int x1, int y1, int x2, int y2, Grid grid)
    {
        // Rules
        // 1. Any live cell with fewer than two live neighbors dies, as if caused by underpopulation.
        // 2. Any live cell with two or three live neighbors lives on to the next generation.
        // 3. Any live cell with more than three live neighbors dies, as if by overpopulation.
        // 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
        // 5. Any live cell with more than 3 neighbors becomes poisoned, and will die if it has fewer than 2 neighbors.
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
                    else if (cells[x, y].numNeighbors > 3)
                    {
                    }
                }
                else
                {
                    if ((x > x1 && x < x2) && (y > y1 && y < y2))
                    {
                        cells[x, y].SetAlive(true);
                        cells[x, y].SetColor(Color.blue);
                    } else if (cells[x, y].numNeighbors == 3)
                    {
                        cells[x, y].SetAlive(true);
                    }
                }
            }
        }
    }

}
