using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public string firstScene;
    public enum GameMode
    {
        Click,
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
        SceneManager.LoadScene(firstScene);
    }

    public void StartClickGame()
    {
        GameMode gameMode = GameMode.Click;
        PlayerPrefs.SetInt("GameMode", (int)gameMode);
        SceneManager.LoadScene(firstScene);
    }
}
