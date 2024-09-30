using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints;

    [SerializeField] private GameObject explosionGo;

    public void Update(){
        if(healthPoints<=0f){
            Instantiate(explosionGo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision){
        Damage damageDealer = collision.gameObject.GetComponent<Damage>();
        if (damageDealer != null)
        {
            float damage = damageDealer.GetDamage();
            healthPoints-=damage;
            debugmsg();
        }
    }

    private void debugmsg(){
        Debug.Log(this.healthPoints);
    }
}
