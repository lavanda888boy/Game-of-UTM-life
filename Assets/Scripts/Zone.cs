using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public void PopulateZone(Grid grid, int x1, int y1, int x2, int y2, Color color)
    {
        for (int y = y1; y < y2; y++)
        {
            for (int x = x1; x < x2; x++)
            {
                // if cell is alive, make it poisoned and change color to green
                if (grid.GetCells()[x, y].isAlive)
                {
                    grid.GetCells()[x, y].isPoisoned = true;
                    grid.GetCells()[x, y].SetColor(color);
                }
            }
        }
    }

    public void ResetZone(Grid grid, int x1, int y1, int x2, int y2)
    {
        for (int y = y1; y < y2; y++)
        {
            for (int x = x1; x < x2; x++)
            {
                // if cell is alive, make it poisoned and change color to blue
                if (grid.GetCells()[x, y].isAlive)
                {
                    grid.GetCells()[x, y].isPoisoned = false;
                    grid.GetCells()[x, y].SetColor(Color.black);
                }
            }
        }
    }
}
