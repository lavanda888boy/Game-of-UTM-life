using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grid : MonoBehaviour
{
    public int width { get; private set; }
    public int height { get; private set; }
    private Cell[,] cells;

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
        cells = new Cell[width, height];
    }

    public void SetCell(int x, int y, Cell cell)
    {
        cells[x, y] = cell;
    }

    public Cell GetCell(int x, int y)
    {
        return cells[x, y];
    }

    public Cell[,] GetCells()
    {
        return cells;
    }

    public void PopulateRandomly()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int rand;
                bool isAlive;
                
                // initialize poison cells within an certain area
                if ((y >= 28 && y <= 40) && (x >= 38 && x <= 50))
                {
                    rand = Random.Range(0, 100);
                    isAlive = rand > 65 ? true : false;
                    
                    rand = Random.Range(0, 100);
                    bool isPoisoned = rand > 60 ? true : false;
                    Cell c;
                    
                    if (isPoisoned)
                    {
                        c = Instantiate(Resources.Load("Prefabs/green_cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                    }
                    else
                    {
                        c = Instantiate(Resources.Load("Prefabs/cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                    }
                    
                    if (isAlive && !isPoisoned)
                    {
                        c.color = "black";
                    } else if (isAlive && isPoisoned)
                    {
                        c.color = "green";
                    }
                    
                    cells[x, y] = c;
                    cells[x, y].SetAlive(isAlive);
                }
                else
                {
                    Cell cell = Instantiate(Resources.Load("Prefabs/cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                    cells[x, y] = cell;
                    // random variable to determine if cell is alive or not
                    rand = Random.Range(0, 100);
                    isAlive = rand > 65 ? true : false;
                    cells[x, y].SetAlive(isAlive); // initial grid with random alive cells

                    if (isAlive)
                    {
                        cells[x, y].color = "black";
                    }
                }
            }
        }
        Camera.main.backgroundColor = Color.white;
    }

    public void PopulateCustom()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int mouseX = Mathf.FloorToInt(mousePosition.x); // mouse position on x axis
            int mouseY = Mathf.FloorToInt(mousePosition.y); // mouse position on y axis

            if (mouseX >= 0 && mouseX < width && mouseY >= 0 && mouseY < height)
            {
                // create a new cell if it doesn't exist already
                if (cells[mouseX, mouseY] == null)
                {
                    Cell cell = Instantiate(Resources.Load("Prefabs/cell", typeof(Cell)), new Vector2(mouseX, mouseY), Quaternion.identity) as Cell;
                    cells[mouseX, mouseY] = cell;
                }

                // set the cell as alive
                cells[mouseX, mouseY].SetAlive(true);
                cells[mouseX, mouseY].color = "black";
            }
        }
    }

    public void PopulateWithDeadCells()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (cells[x, y] == null)
                {
                    Cell cell = Instantiate(Resources.Load("Prefabs/cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                    cells[x, y] = cell;
                    cells[x, y].SetAlive(false);
                    cells[x, y].color = "white";
                }
            }
        }
    }

    public void CountNeighbors()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int numNeighbors = 0;
                int numPoisonedNeighbors = 0;
                // North
                if (y + 1 < height)
                {
                    if (cells[x, y + 1].isAlive)
                    {
                        if (String.Equals(cells[x, y + 1].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                // North East
                if (y + 1 < height && x + 1 < width)
                {
                    if (cells[x + 1, y + 1].isAlive)
                    {
                        if (String.Equals(cells[x + 1, y + 1].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                // East
                if (x + 1 < width)
                {
                    if (cells[x + 1, y].isAlive)
                    {
                        if (String.Equals(cells[x + 1, y].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                // South East
                if (y - 1 >= 0 && x + 1 < width)
                {
                    if (cells[x, y + 1].isAlive)
                    {
                        if (String.Equals(cells[x, y + 1].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                // South
                if (y - 1 >= 0)
                {
                    if (cells[x, y - 1].isAlive)
                    {
                        if (String.Equals(cells[x, y - 1].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                // South West
                if (y - 1 >= 0 && x - 1 >= 0)
                {
                    if (cells[x - 1, y - 1].isAlive)
                    {
                        if (String.Equals(cells[x - 1, y - 1].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                // West
                if (x - 1 >= 0)
                {
                    if (cells[x - 1, y].isAlive)
                    {
                        if (String.Equals(cells[x - 1, y].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                // North West
                if (y + 1 < height && x - 1 >= 0)
                {
                    if (cells[x - 1, y + 1].isAlive)
                    {
                        if (String.Equals(cells[x - 1, y + 1].color, "green"))
                        {
                            numPoisonedNeighbors++;
                        }

                        numNeighbors++;
                    }
                }
                cells[x, y].numNeighbors = numNeighbors;
                cells[x, y].numPoisonedNeighbors = numPoisonedNeighbors;
            }
        }
    }
}
