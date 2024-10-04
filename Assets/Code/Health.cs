using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints;

    [SerializeField] private GameObject explosionGo;
    [SerializeField] private bool hasHp, isPlayer;
    public GameObject hpbar;
    private float totalhp;
    private bool isDestroyed= false;
    void Awake(){
        totalhp = healthPoints;
    }

    public void Update(){
        if(healthPoints<=0 && !isDestroyed){
            isDestroyed=true;
            Instantiate(explosionGo, transform.position, transform.rotation);
            if(!isPlayer){
                Destroy(gameObject);
            }else{
                foreach (Transform child in transform) {
                    child.gameObject.SetActive(false);
                }
            }
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

    public float RemainingHP(){
        return healthPoints;
    }
}
