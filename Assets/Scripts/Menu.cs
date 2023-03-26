using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Scene;
    public void StartRandomGame()
    {
        GameMode.Mode = GameMode.Modes.Random;
        SceneManager.LoadScene(Scene);
    }

    public void StartCustomGame()
    {
        GameMode.Mode = GameMode.Modes.Custom;
        SceneManager.LoadScene(Scene);
    }

    public void StartExplodingGame()
    {
        GameMode.Mode = GameMode.Modes.Exploding;
        SceneManager.LoadScene(Scene);
    }

    public void StartReverseGame()
    {
        GameMode.Mode = GameMode.Modes.Reverse;
        SceneManager.LoadScene(Scene);
    }

    public void BackToMenu()
    {
        ToggleHandler.ResetToggles();
        SetNrGenerations.nrOfGenerations = 0;
        SceneManager.LoadScene(Scene);
    }
}
