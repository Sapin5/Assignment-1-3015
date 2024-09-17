using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Gmae object variable for holding canvas
    public GameObject startscreen = null;
    public GameObject Endscreen = null;
    public GameObject WinScreen = null;
    public GameObject playerObj;
    // In place to control when spawners start spawning
    public static bool start = false;
    public static bool GameEnds = false;
    public static int bossCount = 2;
    // sets timescale to 0 to disable all game mechanics
    // befose the start button is hit
    // kind of brute force game start but it works
    void Awake(){
        Time.timeScale = 0;
        Endscreen.SetActive(false);
    }

    // Starts the game
    public void Onstart(){
        // Setting to true allows the spawners to start running
        start=true;
        // Sets time scale to 1 which allows game to start running
        Time.timeScale= 1;

        // Disables start screen
        startscreen.SetActive(false);
        WinScreen.SetActive(false);
    }

    void Update(){
        int hp = PlayerDeath.singleton.PlayerHP();
        if(hp <= 0){
            Time.timeScale = 0;
            GameEnds = true;
            Endscreen.SetActive(true);
        }
        if(bossCount <= 0){
            GameEnds = true;
            Time.timeScale = 0;
            WinScreen.SetActive(true);
        }
    }
}
