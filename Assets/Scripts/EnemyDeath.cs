using UnityEngine;
public class EnemyDeath : MonoBehaviour
{
    // Explosion prefab hodler 
    public GameObject explosionGo;
    
    // Detects Collsions in order to destroy itself 
    private void OnCollisionEnter2D(Collision2D collision){

        /*
        If the game object collides with a player or another enemy
        it will remove itself from the gameworld and spawn an explosion
        If it collides with a bullet it will remove itself
        but not add an explosion as the bullet is already creating one
        */
        if(collision.gameObject.CompareTag("Player") || 
        collision.gameObject.CompareTag("Enemy")) {
            // Removes game object
            Destroy(gameObject);
            // Spawns an explosion
            Instantiate(explosionGo, transform.position, transform.rotation);
        }else if(collision.gameObject.CompareTag("Bullet"))
        {   
            // Remoces game object
            Destroy(gameObject);
        }
    }
    
}
