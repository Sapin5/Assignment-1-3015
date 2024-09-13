using UnityEngine;
public class EnemyDeath : MonoBehaviour
{
    public GameObject explosionGo;
    private void OnCollisionEnter2D(Collision2D collision){
        Death(collision);
    }

    public void Death(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") || 
        collision.gameObject.CompareTag("Enemy")) {
            Destroy(this.gameObject);
            Instantiate(explosionGo, transform.position, transform.rotation);
        }else if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
    
}
