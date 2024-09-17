using UnityEngine;
public class TouchingBorder : MonoBehaviour
{
    // Detects if gameObject has collides with a wall
    private void OnCollisionEnter2D(Collision2D collision){

        // Using tags Because there are two sets of walls to prevent enemies
        // from flying out of bounds

        // Teleports objects to new X Y position based on which 
        // wall they have collided with
        if(collision.gameObject.CompareTag("BorderRight")) {
            transform.position = new Vector3(-8.8f, transform.position.y, 0);  
        }else if(collision.gameObject.CompareTag("BorderLeft")){
            transform.position = new Vector3(8.8f, transform.position.y, 0); 
        }else if(collision.gameObject.CompareTag("BorderTop")){
            transform.position = new Vector3(transform.position.x, -3.9f, 0); 
        }else if(collision.gameObject.CompareTag("BorderBottom")){
            transform.position = new Vector3(transform.position.x, 5.9f, 0); 
        }
    }
}
