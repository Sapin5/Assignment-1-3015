using UnityEngine;

public class Spawner : MonoBehaviour
{   
    // List of enemy game objects
    public GameObject[] enemyPrefab;
    // Spawn interval
    public float interval = 100;
    // Counter for spawning
    private float counter = 0;
    // Valid X cordinate spawn points
    private float[] validSpawn = {-8.8f, 8.8f};

    void Update()
    {   
        // Runs only when the game has started
        if(StartGame.start == true){
            // Increments counter to track wether or not enemy should spawn
            counter += 1;
            // if counter is eual to interval it will spawn an enemy
            if(counter >= interval){
                // Resets Counter to restart count cycle
                counter = 0;
                // Instantiates new enemy
                Instantiate(enemyPrefab[0], new Vector3(SpawnLocation(validSpawn), 6f, 0), transform.rotation);
            }
        }
    }
    // Selects a random Spawn location along the X axis and returns it
    private float SpawnLocation(float[] temp){
        float ok = Random.Range(temp[0], temp[1]);
        return ok;
    }
}