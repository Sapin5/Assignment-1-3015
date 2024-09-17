using UnityEngine;

public class BossDeath : MonoBehaviour
{
    // Boss HP
    public int healthPoints;

    // Explosion object fro when boss dies
    public GameObject explosionGo;

    // Runs when boss collides whith anything
    private void OnCollisionEnter2D(Collision2D collision){

        // If the object it collided with is a bullet lowers HP by 1
        if(collision.gameObject.CompareTag("Bullet")){
            healthPoints-=1;
        }

        // Destroys gameobject (boss) once HP hits 0
        if(healthPoints <= 0){
            Destroy(this.gameObject);

            // Creates explosion game object
            Instantiate(explosionGo, transform.position, transform.rotation);
        }
    }
}
