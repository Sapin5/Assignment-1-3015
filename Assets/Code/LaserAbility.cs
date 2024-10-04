using UnityEngine;
public class LaserAbility : MonoBehaviour{
    // Cool for checking key press
    private bool isKeyPressed;

    // Sprites for cisualization 
    public GameObject windUpanimation, player, laser;

    // Controls Firing State
    public enum FiringState {Ready, WindUp, Firing, Winddown, OnCooldown};
    
    // Timer for switching states
    public float timer;
    
    // firing state
    public FiringState firingState;

    // contanct filter for Raycasting
    public ContactFilter2D contactFilter;

    // Update is called once per frame
    void Update()
    {  
        // Sets to true when space is pressed for 
        isKeyPressed = Input.GetKeyDown(KeyCode.Space);
        
        // Switches alternates through firing states for firing huge laser
        switch (firingState){
            case FiringState.Ready:

                // Switches firning state to Wind up
                if(isKeyPressed){
                    firingState = FiringState.WindUp;
                }
                break;

            case FiringState.WindUp:

                // Spawns wind up animation when firingstate is initially switched 
                if(timer==0){
                    Instantiate(windUpanimation, transform.position,
                                 transform.rotation, player.transform);
                }
                // Calls Timer to start a countdown before switching states
                Timer(1f, FiringState.Firing);
                break;

            case FiringState.Firing:

                // enables laser sprite 
                laser.SetActive(true);
                // Calls Timer to start a countdown before switching states
                Timer(2f, FiringState.Winddown);
                // calls cast some Rays to create raycast
                CastSomerRays();
                break;

            case FiringState.Winddown:
                // Spawns wind up animation when firingstate is initially switched 
                if(timer==0){

                    // Creates clone of wind up animation to show gun is winding down
                    GameObject cvfx = Instantiate(windUpanimation, transform.position,
                                 transform.rotation, player.transform);

                    // Alters colour of sprite to show a wind down
                    SpriteRenderer rend = cvfx.GetComponent<SpriteRenderer>();
                    rend.material.color = Color.white;
                }
                // Hides laser
                laser.SetActive(false);
                // Calls Timer to start a countdown before switching states
                Timer(0.5f, FiringState.OnCooldown);
                break;

            case FiringState.OnCooldown:
                // Calls Timer to start a countdown before switching states
                Timer(2f, FiringState.Ready);
                break;
        }
    }

    // Timer that counts up to N seconds for swiching states
    public void Timer(float delay, FiringState firingState){
        timer+=Time.deltaTime;
        // Switches when timer becomes greater than the delay
        if(timer>delay){
            // resets timer
            timer=0;
            // Switches firingState to whatver state was passed
            this.firingState = firingState;
        }
    }

    // Casts Raycast on raycast to raycats
    public void CastSomerRays(){
        // Creates array of raycast layers
        RaycastHit2D[] results = new RaycastHit2D[10];
        // Draws Ray to visualize where raycast is firing
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up)*10f, Color.red);
        // casts raycast, returns int for number of valid objects hit
        Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), contactFilter, results);
        // enables laser to visualize what player has hit
        laser.SetActive(true);
        
        // iterates through the results of what was hit
        foreach (var r in results) {
            // Checks if collider is not null 
            if(r.collider !=null){
                // trys to get compenent health from object that was hit
                if(r.collider.TryGetComponent<Health>(out var hp))
                {
                    // Deals 2 damage to anything that has Health
                    hp.TakeEnemyDmg(2);
                }
            }
        }
    }
}
