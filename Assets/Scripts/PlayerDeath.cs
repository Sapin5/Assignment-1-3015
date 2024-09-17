using UnityEngine;
public class PlayerDeath : MonoBehaviour
{
    // Exlposion gameobjegt
    public GameObject explosionGo;
    
    //Player HP
    private static int hp = 10;

    // Allows other Scripts to access HP
    public static PlayerDeath singleton;

    //Sets singleton to this game object
    void Awake(){
        singleton = this;
    }

    // On collsion with Enemy loses HP
    private void OnCollisionEnter2D(Collision2D collision){

        // Checks if object collided with was an enemy
        if(collision.gameObject.CompareTag("Enemy")){
            // Reduces HP
            hp-=1;
        }

        // If HP is 0 removes this object from game
        if(hp <= 0){
            // Creates new explosion object
            Instantiate(explosionGo, transform.position, transform.rotation);

            //Removes this game object
            Destroy(gameObject);
        }
    }
    
    // Returns players HP
    public int PlayerHP(){
        return hp;
    }
}
