using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Scene;
    public enum GameMode
    {
        Custom,
        Random,
    }

    public void StartRandomGame()
    {
        GameMode gameMode = GameMode.Random;
        PlayerPrefs.SetInt("GameMode", (int)gameMode);
        SceneManager.LoadScene(Scene);
    }

    public void StartCustomGame()
    {
        GameMode gameMode = GameMode.Custom;
        PlayerPrefs.SetInt("GameMode", (int)gameMode);
        SceneManager.LoadScene(Scene);
    }

    public void BackToMenu()
    {
        SetNrGenerations.nrOfGenerations = 0;
        SceneManager.LoadScene(Scene);
    }
}
