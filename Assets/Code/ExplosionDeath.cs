using UnityEngine;
public class ExplosionDeath : MonoBehaviour
{
    // death timer for explosion
    public float deathTimer = 1f;

    // runs on start
    void Start()
    {   
        // Destroys explosion after X seconds
        Destroy(gameObject, deathTimer);
    }
}
