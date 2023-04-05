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
    Zone toxicZone = new Zone();
    Zone friendlyZone = new Zone();
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
                if (ToggleHandler.ToxicZone)
                {
                    toxicZone.ToxicZone(grid, 10, 5, 25, 20);
                    if (updateCounter % 5 == 0) populationController.KillRandomToxicCells(grid);
                }
                else toxicZone.ResetZone(grid, Color.green);
                if (ToggleHandler.FriendlyZone)
                    friendlyZone.FriendlyZone(grid, 40, 30, 66, 40);
                else friendlyZone.ResetZone(grid, Color.blue);
                updateCounter++;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
