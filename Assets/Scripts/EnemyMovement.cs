using System;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D physicsBody;
	private Vector2 playerPosition;
	private float radian, randSpeed, evenmoremath;
    public float speed = 5;

	// Use this for initialization
	private GameObject playerObj = null;
	void Start(){
		playerObj = GameObject.FindGameObjectWithTag("Player");

		randSpeed = UnityEngine.Random.Range(0.1f, 1f);
		physicsBody = GetComponent<Rigidbody2D>();
	}
	//12345678901234567890123456789012345678901234567890123456789012345678901234567890
	//I dont knwo what im doing anymore
	// Update is called once per frame
	void Update () {

		float[] player = {playerObj.transform.position.x,
						  playerObj.transform.position.y};

		float[] enemy = {this.transform.position.x, this.transform.position.y};

		float[] temp = angle();
		evenmoremath = rotation(player, enemy, temp[2]);
		targetting(evenmoremath);

		playerPosition = new Vector2(temp[0], temp[1]);
	}

	public float[] angle(){
		float xvalue = playerObj.transform.position.x - 
						this.transform.position.x;
		float yvalue = playerObj.transform.position.y - 
						this.transform.position.y;

		radian = MathF.Atan(yvalue/xvalue);

		float[] output = {xvalue, yvalue, radian};

		return output;
	}

	public float rotation(float[] player, float[] enemy, float radian){
	
		if(player[0] < enemy[0] && player[1] < enemy[1]){
			evenmoremath = ((float)radian*Mathf.Rad2Deg) + 90;
		}else if(player[0] > enemy[0] && player[1] < enemy[1]){
			
			evenmoremath = ((float)radian*Mathf.Rad2Deg) - 90;
		}else if(player[0] > enemy[0] && player[1] > enemy[1]){

			evenmoremath = ((float)radian*Mathf.Rad2Deg) - 90;
		}else{
			evenmoremath =  ((float)radian*Mathf.Rad2Deg) + 90;
		}

		return evenmoremath;
	}


	public void targetting(float plaerRotation){

		Quaternion target = Quaternion.Euler(0, 0, plaerRotation);
		transform.rotation = Quaternion.Slerp(transform.rotation, 
											  target, Time.deltaTime*speed);
                                              
		float Rotation;
		if (transform.eulerAngles.z <= 180f){
			Rotation = transform.eulerAngles.z;
		} else {
			Rotation = transform.eulerAngles.z - 360f;
		}

		if(Rotation <= plaerRotation+5f && Rotation >= plaerRotation-5f){
			//Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAaaAAAAAAAAAAAAAAAaaaaAAAA");
		}

	}

	private void FixedUpdate() 
    {
        physicsBody.AddForce(randSpeed * playerPosition);
    }
}