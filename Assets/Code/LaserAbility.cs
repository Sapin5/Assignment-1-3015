using UnityEngine;
public class LaserAbility : MonoBehaviour
{
    private bool isFiringButtonDown = false;
    public GameObject windUpanimation, player;

    public enum FiringState {Ready, WindUp, Firing, Winddown, OnCooldown};
    public float timer;
    public FiringState firingState;
    // Update is called once per frame
    void Update()
    {
        isFiringButtonDown = Input.GetKeyDown(KeyCode.Space);

        if(isFiringButtonDown){
            firingState = FiringState.WindUp;
            Debug.Log("keypressed");
        }
        

        switch (firingState){
            case FiringState.Ready:
                Debug.Log("ready");
                break;

            case FiringState.WindUp:
                Debug.Log("Winding up");
                
                if(timer==0){
                    Instantiate(windUpanimation, transform.position, transform.rotation, player.transform);
                }

                timer+=Time.deltaTime;
                if(timer>1){
                    firingState = FiringState.Firing;
                    timer=0;
                }
                break;




            case FiringState.Firing:
                timer += Time.deltaTime;
                if(timer > 1) {
                    firingState = FiringState.Winddown;
                    timer = 0;
                }
                
                RaycastHit2D hit = Physics2D.Raycast(player.transform.position, 
                                                player.transform.up, Mathf.Infinity);
                if (hit.collider != null) {
                    
                    Debug.DrawLine(transform.position, hit.point);
                    
                    //Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);
                    
                    Debug.Log("Hit Asteroid");
                }

                
                Debug.Log("Firing");
                break;


            case FiringState.Winddown:
                Debug.Log("Winding Down");
                timer+=Time.deltaTime;
                if(timer>1){
                    firingState = FiringState.OnCooldown;
                    timer=0;
                }
                break;
            case FiringState.OnCooldown:
            Debug.Log("Cools Down");
                timer+=Time.deltaTime;
                if(timer>3){
                    firingState = FiringState.Ready;
                    timer=0;
                }
                break;
        }
    }
}
