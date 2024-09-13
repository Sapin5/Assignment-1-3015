using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D physicsBody;
	private Vector2 directionalInput, mousePosition;
	private float radian, speed = 5;
    public float evenmoremath;
	public Vector2 moveForce = new Vector2(1f, 1f);

	// Use this for initialization
	private GameObject playerObj = null;
	void Start(){
		if (playerObj ==null){
			playerObj = GameObject.FindGameObjectWithTag("Player");
		}

		physicsBody = GetComponent<Rigidbody2D>();
	}
	//12345678901234567890123456789012345678901234567890123456789012345678901234567890
	//I dont knwo what im doing anymore
	// Update is called once per frame
	void Update () {

		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		
		float[] player = {playerObj.transform.position.x,
						  playerObj.transform.position.y};

		float[] mouse = {mousePosition[0], mousePosition[1]};

		float[] temp = angle();
		evenmoremath = rotation(player, mouse, temp[2]);
		targetting(evenmoremath);

		directionalInput = new Vector2(temp[0], temp[1]);
	}

	public float[] angle(){
		float xvalue = mousePosition[0] - 
						playerObj.transform.position.x;
		float yvalue = mousePosition[1] - 
						playerObj.transform.position.y;

		radian = MathF.Atan(yvalue/xvalue);

		float[] output = {xvalue, yvalue, radian};

		return output;
	}

	public float rotation(float[] player, float[] mouse, float radian){
	
		if(player[0] < mouse[0] && player[1] < mouse[1]){
			evenmoremath = ((float)radian*Mathf.Rad2Deg) - 90;
		}else if(player[0] > mouse[0] && player[1] < mouse[1]){
			
			evenmoremath = ((float)radian*Mathf.Rad2Deg) + 90;
		}else if(player[0] > mouse[0] && player[1] > mouse[1]){

			evenmoremath = ((float)radian*Mathf.Rad2Deg) + 90;
		}else{
			evenmoremath =  ((float)radian*Mathf.Rad2Deg) - 90;
		}

		return evenmoremath;
	}


	public void targetting(float mouseR){

		Quaternion target = Quaternion.Euler(0, 0, mouseR);
		transform.rotation = Quaternion.Slerp(transform.rotation, 
											  target, Time.deltaTime*speed);
                                              
		float Rotation;
		if (playerObj.transform.eulerAngles.z <= 180f){
			Rotation = playerObj.transform.eulerAngles.z;
		} else {
			Rotation = playerObj.transform.eulerAngles.z - 360f;
		}

		if(Rotation <= mouseR+10f && Rotation >= mouseR-10f){
			//Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAaaAAAAAAAAAAAAAAAaaaaAAAA");
		}

	}

	private void FixedUpdate() 
    {
        physicsBody.AddForce(moveForce * directionalInput);
    }
}