using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Component for physics calculations
    private Rigidbody2D physicsBody;
	// Store players position and mouse position
	private Vector2 targetPos, mousePosition;
	// rotation rotationSpeed
	[SerializeField] private float rotationSpeed = 5;
	// Movement force
	public Vector2 moveForce = new(1f, 1f);
	// Player game object prefab holder
	private GameObject playerObj = null;

	// Allows functions in script to be called without reference in other script
	public static Movement singleton;

	// Runs on object spawn
	void Awake(){
		singleton = this;
	}

	// Runs when game starts
	void Start(){
		
		// If the player object has not been declared already will
		// search for it by tag
		if (playerObj ==null){
			playerObj = GameObject.FindGameObjectWithTag("Player");
		}
		// Get the Rigidbody2D component attached to this GameObject
		physicsBody = GetComponent<Rigidbody2D>();
	}
// Fancy ruler so code stays under 74 charcacters for readability
//123456789012345678901234567890123456789012345678901234567890123456789012345678901234

	// Update is called once per frame
	void Update () {
		// Gets current mouse position on screen
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		
		// Stores players X and Y position to make calling easier
		float[] player = {playerObj.transform.position.x,
						  playerObj.transform.position.y};

		// Stores mouse position to make calling easier
		float[] mouse = {mousePosition[0], mousePosition[1]};

		// Calls angle to find angle of rotation to mouse
		float[] temp = angle(player, mouse);
		
		// Rotates towards Nouse 
		targetting(temp[0]);

		// Creates 2D vector which will be used to move player towards mouse
		targetPos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	/*
		Takes two values 
		Player array which has current X and Y pos
		Enemy array which has current X and Y pos
	*/
	public float[] angle(float[] player, float[] mouse){
		// Calculates difference between x and Y values 
		float xvalue = mousePosition[0] - 
						playerObj.transform.position.x;
		float yvalue = mousePosition[1] - 
						playerObj.transform.position.y;

		// Calculate the angle in radians using Atan
		// And converts radians back to degrees
		float radian = MathF.Atan(yvalue/xvalue)*Mathf.Rad2Deg;

		// Adjust rotation based on the relative position of player and mouse
		if(player[0] < mouse[0] && player[1] < mouse[1]){
			radian-= 90;
		}else if(player[0] > mouse[0] && player[1] < mouse[1]){
			radian+= 90;
		}else if(player[0] > mouse[0] && player[1] > mouse[1]){
			radian+= 90;
		}else{
			radian-= 90;
		}

		// return the difference Between X, Y, and the Degree to rotate
		float[] output = {radian};
		return output;
	}

	// Rotates Gameobject Towards Given Target	
	public void targetting(float mouseR){
		// Create a quaternion to rotate the enemy towards the target angle
		Quaternion target = Quaternion.Euler(0, 0, mouseR);
		// Smoothly rotate the enemy towards the target using Slerp
		transform.rotation = Quaternion.Slerp(transform.rotation, 
											  target, Time.deltaTime*rotationSpeed);
	}

	// Returns Players current rotationSpeed
	public float totalspeed(){
		// Converts all values to positive
		float temmp = Mathf.Abs(targetPos[1]);
		float temp2 = Mathf.Abs(targetPos[0]);
		// adds the values 
		float temp3 = temmp+temp2;
		// returns the current values /10 
		// this was written last minute, still needs the math to be fixed
		return temp3/10;
	}

	private void FixedUpdate() 
    {
		// Applies force to character in order to move them
        physicsBody.AddForce(moveForce * targetPos);
    }
}