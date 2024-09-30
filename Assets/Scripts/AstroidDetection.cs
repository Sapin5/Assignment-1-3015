using UnityEngine;

public class AstroidDetection : MonoBehaviour
{
    private Vector2 curPos;
    private Vector2 astroidPos;
    public void Update(){
        curPos = new Vector2(transform.position.x, transform.position.y);
    }
    public void OnTriggerEnter2D(Collider2D collider){
        
        astroidPos = new Vector2(collider.transform.position.x,
                                collider.transform.position.y);
        Debug.DrawLine(curPos, astroidPos);
    }
}
