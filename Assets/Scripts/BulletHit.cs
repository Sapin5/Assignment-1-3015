using UnityEngine;

public class BulletHit : MonoBehaviour
{   
    // Bullet explosion for whenever it hits anything
    public GameObject explosionGo;

    // Whenever a bullet collides with anything it creates an explosion game object
    private void OnCollisionEnter2D(Collision2D collision){
        // Creates explosion game object
        Instantiate(explosionGo, transform.position, transform.rotation);
        // Removes this Gameobject from the game
        Destroy(gameObject);
    }
}
