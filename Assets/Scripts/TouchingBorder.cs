using UnityEngine;
public class TouchingBorder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "BorderRight") {
            transform.position = new Vector3(-8.8f, transform.position.y, 0);  
        }else if(collision.gameObject.tag == "BorderLeft"){
            transform.position = new Vector3(8.8f, transform.position.y, 0); 
        }else if(collision.gameObject.tag == "BorderTop"){
            transform.position = new Vector3(transform.position.x, -3.9f, 0); 
        }else if(collision.gameObject.tag == "BorderBottom"){
            transform.position = new Vector3(transform.position.x, 5.9f, 0); 
        }
    }
}
