using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isAlive = false;
    public int numNeighbors = 0;
    public int numPoisonedNeighbors = 0;
    public int numFriendlyNeighbors = 0;
    public bool isPoisoned = false;
    public bool isFriendly = false;

    public void SetAlive(bool alive)
    {
        isAlive = alive;
        GetComponent<SpriteRenderer>().enabled = alive;
    }

    public void SetColor(Color color)
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        materialPropertyBlock.SetColor("_Color", color);
        GetComponent<Renderer>().SetPropertyBlock(materialPropertyBlock);
    }
}
