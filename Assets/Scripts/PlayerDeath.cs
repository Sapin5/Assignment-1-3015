using UnityEngine;
using UnityEngine.Events;
public class PlayerDeath : MonoBehaviour
{
    public UnityEvent OnCollisionEnter_Event = new UnityEvent();
    
    public int hp = 10;

    private void OnCollisionEnter2D(Collision2D collision){
        if(hp <= 0){
            Destroy(this.gameObject);
        }
    }

    public void LoseHP(){
        hp--;
    }

    public void Playerdead(){
        
    }
}
