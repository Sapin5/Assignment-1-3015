using UnityEngine;

public class BulletHit : MonoBehaviour
{   
    // Bullet explosion for whenever it hits anything
    public GameObject explosionGo;

    [SerializeField]private bool enemyBullet;
    // Whenever a bullet collides with anything it creates an explosion game object
    private void OnCollisionEnter2D(Collision2D collision){
        // Creates explosion game object
        Instantiate(explosionGo, transform.position, transform.rotation);
        // Removes this Gameobject from the game
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(!enemyBullet){
            // Creates explosion game object
            Instantiate(explosionGo, transform.position, transform.rotation);
            // Removes this Gameobject from the game
            Destroy(gameObject);
        }
    }
}
