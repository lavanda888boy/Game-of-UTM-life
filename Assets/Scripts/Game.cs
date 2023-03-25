using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static int SCREEN_WIDTH = 86;
    private static int SCREEN_HEIGHT = 48;

    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    void Start()
    {
        PlaceCells();
    }

    void Update()
    {

    }

    void PlaceCells()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                Cell cell = Instantiate(Resources.Load("Prefabs/cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell;
                grid[x, y].SetAlive(RandomAliveCell()); // initial grid with random alive cells
            }
        }
        Camera.main.backgroundColor = Color.white;
    }

    bool RandomAliveCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > 85)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
