using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public enum Modes
    {
        Custom,
        Random,
        Exploding,
        Reverse,
    }

    public static Modes Mode { get; set; }
}
