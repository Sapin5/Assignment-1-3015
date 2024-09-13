using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public int healthPoints = 10;
    public GameObject explosionGo;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Bullet")){
            healthPoints-=1;
        }

        if(healthPoints <= 0){
            Destroy(this.gameObject);
            Instantiate(explosionGo, transform.position, transform.rotation);
        }
    }
}
