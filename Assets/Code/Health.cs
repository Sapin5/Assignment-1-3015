using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints;

    [SerializeField] private GameObject explosionGo;

    public GameObject hpbar;
    private float totalhp;
    void Awake(){
        totalhp = healthPoints;
    }

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
            TakeEnemyDmg(damage);
            debugmsg();
        }
    }

    public void TakeEnemyDmg(float damage){
        healthPoints-=damage;
        hpbar.transform.localScale = new Vector2(healthPoints/totalhp, 1);
    }

    private void debugmsg(){
        Debug.Log(this.healthPoints);
    }
}
