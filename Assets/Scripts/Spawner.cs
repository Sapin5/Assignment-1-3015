using System.Numerics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float interval = 100;
    private float counter = 0;
    private float[] validSpawn = {-8.8f, 8.8f};
    void Update()
    {   
        counter += 1;
        if(counter >= interval){
            counter = 0;
            Instantiate(enemyPrefab[0], new UnityEngine.Vector3(SpawnLocation(validSpawn), 6f, 0), transform.rotation);
        }
    }

    private float SpawnLocation(float[] temp){
        float ok = Random.Range(temp[0], temp[1]);
        return ok;
    }
}