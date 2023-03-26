using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static int SCREEN_WIDTH = 86;
    private static int SCREEN_HEIGHT = 48;
    public float speed = 0.05f;
    private float timer = 0.0f;
    private bool ModeSelect = false;

    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    public enum GameMode
    {
        Click,
        Random,
    }
    public GameMode gameMode;

    void Start()
    {
        gameMode = (GameMode)PlayerPrefs.GetInt("GameMode");
        Debug.Log(gameMode);
        Camera.main.backgroundColor = Color.white;
        if (gameMode == GameMode.Random)
        {
            Debug.Log("Random");
            PlaceCellsRandomly();
        }
        else if (gameMode == GameMode.Click)
        {
            Debug.Log("Click");
        }

    }

    void Update()
    {
        if (gameMode == GameMode.Click)
        {
            PlaceCellsMouseClick();
        }
        else if (gameMode == GameMode.Random)
        {
            if (timer >= speed)
            {
                timer = 0.0f;
                CountNeighbors();
                PopulationControl();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    void PlaceCellsRandomly()
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

    void PlaceCellsMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int mouseX = Mathf.FloorToInt(mousePosition.x); // mouse position on x axis
            int mouseY = Mathf.FloorToInt(mousePosition.y); // mouse position on y axis

            if (mouseX >= 0 && mouseX < SCREEN_WIDTH && mouseY >= 0 && mouseY < SCREEN_HEIGHT)
            {
                // create a new cell only if it doesn't exist already
                if (grid[mouseX, mouseY] == null)
                {
                    Cell cell = Instantiate(Resources.Load("Prefabs/cell", typeof(Cell)), new Vector2(mouseX, mouseY), Quaternion.identity) as Cell;
                    grid[mouseX, mouseY] = cell;
                    grid[mouseX, mouseY].SetAlive(true);
                }
            }
        }
    }


    bool RandomAliveCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > 65)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CountNeighbors()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                int numNeighbors = 0;

                // North
                if (y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // North East
                if (y + 1 < SCREEN_HEIGHT && x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x + 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // East
                if (x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x + 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // South East
                if (y - 1 >= 0 && x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x + 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // South
                if (y - 1 >= 0)
                {
                    if (grid[x, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // South West
                if (y - 1 >= 0 && x - 1 >= 0)
                {
                    if (grid[x - 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // West
                if (x - 1 >= 0)
                {
                    if (grid[x - 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // North West
                if (y + 1 < SCREEN_HEIGHT && x - 1 >= 0)
                {
                    if (grid[x - 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                grid[x, y].numNeighbors = numNeighbors;
            }
        }
    }

    void PopulationControl()
    {
        // Rules
        // 1. Any live cell with fewer than two live neighbors dies, as if caused by underpopulation.
        // 2. Any live cell with two or three live neighbors lives on to the next generation.
        // 3. Any live cell with more than three live neighbors dies, as if by overpopulation.
        // 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                if (grid[x, y].isAlive)
                {
                    if (grid[x, y].numNeighbors != 2 && grid[x, y].numNeighbors != 3)
                    {
                        grid[x, y].SetAlive(false);
                    }
                }
                else
                {
                    if (grid[x, y].numNeighbors == 3)
                    {
                        grid[x, y].SetAlive(true);
                    }
                }
            }
        }
    }
}
