using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int SCREEN_WIDTH = 86;
    private static int SCREEN_HEIGHT = 48;
    public float speed = 0.05f;
    private float timer = 0.0f;
    private int updateCounter = 0;
    private int nrOfGenerations = int.MaxValue;
    Grid grid = new Grid(SCREEN_WIDTH, SCREEN_HEIGHT);
    PopulationController populationController = new PopulationController();
    void Start()
    {
        Camera.main.backgroundColor = Color.white;
        if (GameMode.Mode == GameMode.Modes.Random)
        {
            grid.PopulateRandomly();
        }

    }

    // Update is called once per frame
    void Update()
    {
        nrOfGenerations = (SetNrGenerations.nrOfGenerations != 0) ? SetNrGenerations.nrOfGenerations : nrOfGenerations;
        if (updateCounter >= nrOfGenerations)
        {
            return;
        }
        if (GameMode.Mode == GameMode.Modes.Custom)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                grid.PopulateWithDeadCells();
                GameMode.Mode = GameMode.Modes.Random;
            }
            grid.PopulateCustom();

        }
        else if (GameMode.Mode == GameMode.Modes.Random)
        {
            if (timer >= speed)
            {
                timer = 0.0f;
                grid.CountNeighbors();
                if (ToggleHandler.ExplosionHandler)
                    populationController.ExplosionRules(grid);
                populationController.GeneralRules(grid);
                updateCounter++;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
