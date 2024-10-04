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
    private float hp;
    // sets timescale to 0 to disable all game mechanics
    // befose the start button is hit
    // kind of brute force game start but it works
    void Awake(){
        Time.timeScale = 0;
        Endscreen.SetActive(false);
        hp = playerObj.GetComponent<Health>().RemainingHP();
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

    // calls once per frame
    void Update(){
        // calls playerHP to see how much they have left
        // Lose if HPis 0
        if(hp <= 0){
            //Sets GameEnds to true which will cause remaining Gameobjects
            //Remove themselves from game
             GameEnds = true;

            // Switches canvas to display lose message
            Endscreen.SetActive(true);
        }else{
            hp = playerObj.GetComponent<Health>().RemainingHP();
        }

        // Win if both Bosses are elimnated
        if(bossCount <= 0){
            // Sets GameEnds to true which will cause remaining Gameobjects
            // Remove themselves from game
            GameEnds = true;
            // ADjust Timescale to stop everythin that wasnt removed from moving
            Time.timeScale = 0;

            // Switches canvas to display win message
            WinScreen.SetActive(true);
        }
    }
}
