using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints;

    [SerializeField] private GameObject explosionGo;
    [SerializeField] private bool hasHp;
    public GameObject hpbar;
    private float totalhp;
    void Awake(){
        totalhp = healthPoints;
    }

    public void Update(){
        if(healthPoints<=0){
            Instantiate(explosionGo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.TryGetComponent<Damage>(out var damageDealer))
        {
            float damage = damageDealer.GetDamage();
            TakeEnemyDmg(damage);
            
        }
    }

    public void TakeEnemyDmg(float damage){
        healthPoints-=damage;
        if(hasHp){
            hpbar.transform.localScale = new Vector2(healthPoints/totalhp, 1);
        }
    }
}
