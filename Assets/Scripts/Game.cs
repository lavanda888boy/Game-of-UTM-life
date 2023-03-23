using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static int SCREEN_WIDTH = 64;
    private static int SCREEN_HEIGHT = 48;

    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    void Start()
    {
        PlaceCells();
    }

    void Update()
    {
        
    }

    void PlaceCells ()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                Cell cell = Instantiate(Resources.Load("Prefabs/cell.png", typeof(Cell)), new Vector2 (x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell;
            }
        }
    }
}
