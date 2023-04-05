using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isAlive = false;
    public int numNeighbors = 0;
    public int numPoisonedNeighbors = 0;
    public string color = "white";

    public void SetAlive(bool alive)
    {
        isAlive = alive;
        GetComponent<SpriteRenderer>().enabled = alive;
    }
}
