using UnityEngine;

public class Boost : MonoBehaviour
{   
    // sprites for thrusters
    public SpriteRenderer mainFlame, leftFlame, rightFlame;
    // player game object
    private GameObject playerObj;
    // runs on game start
    void Start()
    {   
        // sets playerObj as current objeect it is attached to
       	if (playerObj == null){
			playerObj = gameObject;
		}
    }

    // Update is called once per frame
    void Update()
    {
        // stores the Z axis rotation
        float angelRot = playerObj.transform.eulerAngles.z;
        // calls totalspeed method in movement script to
        // get the distance from the mouse
        float distance = Movement.singleton.Totalspeed();
        
        // Enables and disables thruster sprites
        // based on which way ship is currently rotating
		if (angelRot <= 180f){
            rightFlame.enabled=false;
            leftFlame.enabled=true;
		}else{
            rightFlame.enabled=true;
            leftFlame.enabled=false;
		}
        
        // Enables and disables main ship thruster Based on the distance to mouse
        // hehehaa
        if(distance>=.5){
            mainFlame.enabled=true;
        }else{
            mainFlame.enabled=false;
        }
    }
}
