using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public string Scene;
    public enum GameMode
    {
        Custom,
        Random,
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        SceneManager.LoadScene(Scene);
    }
}
