using UnityEngine;
public class ExplosionDeath : MonoBehaviour
{
    public float deathTimer = 1f;
    void Start()
    {   
        Destroy(gameObject, deathTimer);
    }
}
