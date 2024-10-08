using System;
using System.Linq;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
	// Component for physics calculations
    private Rigidbody2D physicsBody;
	// Store players position and initial position for gameobject
	private Vector2 targetPos, initPos;
	// rotation speed
    public float speed = 5;
	// Bool for wether or not enemy is alrge type or small
	public bool isLarge;
	// player object
	private GameObject playerObj = null;

	// Enemy has different shooting mechanics
	public GameObject enemyShooter;

	// runs at when program is initialized
	void Start(){
		//Disables enemy shooter
		enemyShooter.SetActive(false);
		// finds the player object by looking for tag
		playerObj = GameObject.FindGameObjectWithTag("Player");

		// stores the initial position of the game object
        initPos = transform.position;
		// Moves the position of enemy to avoid some warning messages
        transform.position = new Vector3(transform.position.x-1, transform.position.y+1, 0);

		// Get the Rigidbody2D component attached to this GameObject
		physicsBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if(StartGame.GameEnds == true){
			Destroy(gameObject);
			return;
		}else{
			// Stores player's current position 
			float[] player = {playerObj.transform.position.x,
							playerObj.transform.position.y};

			// Store enemy's current position
			float[] enemy = {this.transform.position.x, this.transform.position.y};

			// Store enemy's initial position
			float[] init2 = {initPos.x, initPos.y};

			float[] temp;

			if(isLarge){
				// Check if player is currently within a radius of X  
				// If the player is within the given radius, will chase player
				// If not it will return to its Origin point n
				if(InRange(player, enemy, 5)){
					// Calls angle to find angle of rotation to player
					temp = angle(player, enemy);
				}else{
					// Calls angle to find angle of rotation to Origin point
					temp = angle(init2, enemy);
				}
			}else{
				temp = angle(player, enemy);
			}

			//Rotates towards Origin
			// Checks if player is within 5 units to the player
			Targetting(temp[2], InRange(player, enemy, 5));
			// Moves towards Origin point
			targetPos = new Vector2(temp[0]/2, temp[1]/2);
		}
	}

	/*
	Takes two values 
	Player array which has current X and Y pos
	Enemy array which has current X and Y pos
	*/
	public float[] angle(float[] player, float[] enemy){
		
		// Calculates difference between x and Y values 
		float xvalue = player[0] - enemy[0];
		float yvalue = player[1] - enemy[1];

		// Calculate the angle in radians using Atan
		// And converts radians back to degrees
		float radian = MathF.Atan(yvalue/xvalue)*Mathf.Rad2Deg;

		// Adjust rotation based on the relative position of player and enemy
		if(player[0] < enemy[0] && player[1] < enemy[1]){
			radian+= 90;
		}else if(player[0] > enemy[0] && player[1] < enemy[1]){
			radian-= 90;
		}else if(player[0] > enemy[0] && player[1] > enemy[1]){
			radian-= 90;
		}else{
			radian+= 90;
		}

		// return the difference Between X, Y, and the Degree to rotate
		float[] output = {xvalue, yvalue, radian};
		return output;
	}

	// Is used to determin wether or not player is within chasing range
	// By calculating distance between two objects, using Dot product
    public bool InRange(float[] player, float[] enemy, int validDist){
		// Calculate distance using Pythagorean theorem
        float xvalue = Mathf.Pow(player[0]-enemy[0], 2);
        float yvalue = Mathf.Pow(player[1]-enemy[1], 2);

		// Get the square root of the sum to find the distance
        float distance = Mathf.Sqrt(xvalue+yvalue);

		// Return true if the distance is less than or equal to 5 units
        if (distance <= validDist){
            return true;
        }else{
            return false;
        }
    }

	// Rotates Gameobject Towards Given Target
	public void Targetting(float Rotation, bool inRange){
		// Create a quaternion to rotate the enemy towards the target angle
		Quaternion target = Quaternion.Euler(0, 0, Rotation);
		// Smoothly rotate the enemy towards the target using Slerp
		transform.rotation = Quaternion.Slerp(transform.rotation, 
											  target, Time.deltaTime*speed);
		
		// temp holds the enemies current rotation
		float _temp;
		if (transform.eulerAngles.z <= 180f){
			_temp = transform.eulerAngles.z;
		} else {
			_temp = transform.eulerAngles.z - 360f;
		}
		
		/*
			Compares rotation to _temp. Rotation represents the angle
			which the enemy has to turn to face the player, _temp is players
			current rotation. if the player is within +- 20 degrees from 
			the target rotation enemy will be allowed to fire, As long as they
			are also within firing range.
		*/
		if(Rotation <= _temp+20f && _temp-20f <= Rotation && inRange){
			// Gets the Sprite Render Componant and switches colour to red
			// To represent iits within firing range
			gameObject.GetComponent<SpriteRenderer>().color = Color.red;
			// enables enemyShooter
			enemyShooter.SetActive(true);
		}else{
			// Changes sprite colour back to white to represent its out of range
			gameObject.GetComponent<SpriteRenderer>().color = Color.white;
			// Hides enemyShooter to disable shooitng
			enemyShooter.SetActive(false);
		}

	}

	// Called at a fixed time interval
	private void FixedUpdate() 
    {   
		// Apply force to move towards targetted position
        physicsBody.AddForce(targetPos);
    }
}