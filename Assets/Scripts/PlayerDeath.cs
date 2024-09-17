using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
public class PlayerDeath : MonoBehaviour
{
    public GameObject explosionGo;
    private static int hp = 10;
    public static PlayerDeath singleton;

    void Awake(){
        singleton = this;
    }
    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Enemy")){
            hp-=1;
        }

        if(hp <= 0){
            Instantiate(explosionGo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
    public int PlayerHP(){
        return hp;
    }
}
