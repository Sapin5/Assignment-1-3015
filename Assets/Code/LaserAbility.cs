using UnityEngine;
public class LaserAbility : MonoBehaviour{
    private bool isKeyPressed;
    public GameObject windUpanimation, player, laser;
    public enum FiringState {Ready, WindUp, Firing, Winddown, OnCooldown};
    public float timer;
    public FiringState firingState;
    public ContactFilter2D contactFilter;
    // Update is called once per frame

    void Update()
    {   
        isKeyPressed = Input.GetKeyDown(KeyCode.Space);
        
        switch (firingState){
            case FiringState.Ready:
                if(isKeyPressed){
                    Debug.Log("pressed");
                    firingState = FiringState.WindUp;
                }
                break;

            case FiringState.WindUp:
            
                if(timer==0){
                    Instantiate(windUpanimation, transform.position,
                                 transform.rotation, player.transform);
                }
            
                Timer(1f, FiringState.Firing);
                break;

            case FiringState.Firing:
                laser.SetActive(true);
                Timer(2f, FiringState.Winddown);
                CastSomerRays();
                break;

            case FiringState.Winddown:
                Debug.Log("Winding down");
                if(timer==0){
                    GameObject cvfx = Instantiate(windUpanimation, transform.position,
                                 transform.rotation, player.transform);
                    Renderer rend = cvfx.GetComponent<Renderer>();
                    rend.material.color = Color.white;
                }
                laser.SetActive(false);
                Timer(0.5f, FiringState.OnCooldown);
                break;

            case FiringState.OnCooldown:
                Timer(2f, FiringState.Ready);
                break;
        }
    }

    public void Timer(float delay, FiringState firingState){
        timer+=Time.deltaTime;
        if(timer>delay){
            timer=0;
            this.firingState = firingState;
        }
    }

    public void CastSomerRays(){
        RaycastHit2D[] results = new RaycastHit2D[10];
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up)*10f, Color.red);
        Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), contactFilter, results);
        laser.SetActive(true);
        
        foreach (var r in results) { 
            if(r.collider !=null){
                r.collider.GetComponent<Health>().TakeEnemyDmg(2);
            }
        }
    }
}
