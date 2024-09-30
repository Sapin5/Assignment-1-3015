using UnityEngine;

public class Spawner : MonoBehaviour
{   
    // List of enemy game objects
    public GameObject[] enemyPrefab;
    // Spawn interval
    public float timer;
    // Counter for spawning
    private float counter = 0;
    // Valid X cordinate spawn points
    private float[] validSpawn = {-8.8f, 8.8f};

    void Update()
    {   
        // Runs only when the game has started
        if(StartGame.start == true && StartGame.GameEnds==false){
            counter += Time.deltaTime;
            if (counter >= timer){
                    Instantiate(enemyPrefab[0], new Vector3(SpawnLocation(validSpawn),
                                        transform.position.y, 0), transform.rotation);
                counter = 0;
            }
        }
    }
    // Selects a random Spawn location along the X axis and returns it
    private float SpawnLocation(float[] temp){
        float ok = Random.Range(temp[0], temp[1]);
        return ok;
    }
}