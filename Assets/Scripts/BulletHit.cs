using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject explosionGo;
    private void OnCollisionEnter2D(Collision2D collision){
        Instantiate(explosionGo, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
