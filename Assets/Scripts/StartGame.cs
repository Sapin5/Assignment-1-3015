using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Gmae object variable for holding canvas
    public GameObject menu = null;

    // In place to control when spawners start spawning
    public static bool start = false;

    // sets timescale to 0 to disable all game mechanics
    // befose the start button is hit
    // kind of brute force game start but it works
    void Awake(){
        Time.timeScale = 0;
    }

    // Starts the game
    public void Onstart(){
        // Setting to true allows the spawners to start running
        start=true;
        // Sets time scale to 1 which allows game to start running
        Time.timeScale= 1;

        // Disables start screen
        menu.SetActive(false);
    }
}
