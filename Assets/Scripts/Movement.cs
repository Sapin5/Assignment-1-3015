using System;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D physicsBody;
	private Vector2 targetPos, mousePosition;
	private float speed = 5;
	public float radian;
	public Vector2 moveForce = new Vector2(1f, 1f);

	// Use this for initialization
	private GameObject playerObj = null;

	public static Movement singleton;
	void Awake(){
		singleton = this;
	}
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

		float[] temp = angle(player, mouse);
		
		targetting(temp[2]);

		targetPos = new Vector2(temp[0], temp[1]);
	}

	public float[] angle(float[] player, float[] mouse){
		float xvalue = mousePosition[0] - 
						playerObj.transform.position.x;
		float yvalue = mousePosition[1] - 
						playerObj.transform.position.y;

		radian = MathF.Atan(yvalue/xvalue)*Mathf.Rad2Deg;

		if(player[0] < mouse[0] && player[1] < mouse[1]){
			radian-= 90;
		}else if(player[0] > mouse[0] && player[1] < mouse[1]){
			radian+= 90;
		}else if(player[0] > mouse[0] && player[1] > mouse[1]){
			radian+= 90;
		}else{
			radian-= 90;
		}
		
		float[] output = {xvalue, yvalue, radian};
		
		return output;
	}

	public void targetting(float mouseR){
		Quaternion target = Quaternion.Euler(0, 0, mouseR);
		transform.rotation = Quaternion.Slerp(transform.rotation, 
											  target, Time.deltaTime*speed);
	}

	public float totalspeed(){
		float temmp = Mathf.Abs(targetPos[1]);
		float temp2 = Mathf.Abs(targetPos[0]);
		float temp3 = temmp+temp2;

		return temp3/10;
	}
	private void FixedUpdate() 
    {
        physicsBody.AddForce(moveForce * targetPos);
    }
}