using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    // total health for player
    [SerializeField] private float healthPoints;

    // Explosioin gameobject
    [SerializeField] private GameObject explosionGo;

    // bool to differntiate player from NPC
    [SerializeField] private bool hasHp, isPlayer;

    // HPbar game object
    public GameObject hpbar;

    // stores totalHP
    private float totalhp;

    // Bool to store if item has already been destroyed or bnot
    private bool isDestroyed= false;
    void Awake(){
        // Sets total HP initially to prevent errors
        totalhp = healthPoints;
    }

    public void Update(){
        // Checks if hp is still greater than 0 
        // and if the object has already been destroyed
        if(healthPoints<=0 && !isDestroyed){
            // Sets isDestroyed to true to prevent multiple explosions
            // From spawning
            isDestroyed=true;
            // Spawns explosion where player died
            Instantiate(explosionGo, transform.position, transform.rotation);
            
            // Gameobjects are destroyed when HP is 0 
            if(!isPlayer){
                Destroy(gameObject);
            }else{
                // iterates through and disables all 
                // childs of player to remove player fromgame
                foreach (Transform child in transform) {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }

    // Runs when something is collided with
    public void OnCollisionEnter2D(Collision2D collision){
        // Checks if object that was collided with has Damage compenent
        if (collision.gameObject.TryGetComponent<Damage>(out var damageDealer))
        {
            // if there is a damage compenent Damage is applied to the
            // health from the damage function
            float damage = damageDealer.GetDamage();
            TakeEnemyDmg(damage);
            
        }
    }

    // applies damage to health
    public void TakeEnemyDmg(float damage){
        healthPoints-=damage;
        if(hasHp){
            // Updates health bar to represent how much health is left
            hpbar.transform.localScale = new Vector2(healthPoints/totalhp, 1);
        }
    }

    // Returns total HP that is left
    public float RemainingHP(){
        return healthPoints;
    }

    // Sets HP for game reset
    public void setHP(){
        // Sets 
        healthPoints = totalhp;
        hpbar.transform.localScale = new Vector2(healthPoints/totalhp, 1);
        foreach(Transform child in transform){
                    child.gameObject.SetActive(true);
        }
    }
}
