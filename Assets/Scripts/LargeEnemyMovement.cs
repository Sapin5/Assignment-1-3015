using System;
using UnityEngine;


public class LargeEnemyMovement : MonoBehaviour
{
    private Rigidbody2D physicsBody;
	private Vector2 playerPosition, initPos;
	private float radian, evenmoremath;
    public float speed = 5;
	// Use this for initialization
	private GameObject playerObj = null;
	void Start(){
		playerObj = GameObject.FindGameObjectWithTag("Player");

        initPos = transform.position;
        transform.position = new Vector3(transform.position.x-1, transform.position.y+1, 0);

		physicsBody = GetComponent<Rigidbody2D>();
	}
	//12345678901234567890123456789012345678901234567890123456789012345678901234567890
	//I dont knwo what im doing anymore
	// Update is called once per frame
	void Update () {

		float[] player = {playerObj.transform.position.x,
						  playerObj.transform.position.y};

		float[] enemy = {this.transform.position.x, this.transform.position.y};

        float[] init2 = {initPos.x, initPos.y};

        if(InRange(player, enemy)){
            float[] temp = angle(player, enemy);
            evenmoremath = Rotation(player, enemy, temp[2]);
            targetting(evenmoremath);
            playerPosition = new Vector2(temp[0], temp[1]);
        }else{
            float[] temp = angle(init2, enemy);
            evenmoremath = Rotation(init2, enemy, temp[2]);
            targetting(evenmoremath);
            playerPosition = new Vector2(temp[0], temp[1]);
        }   
	}

	public float[] angle(float[] player, float[] enemy){
		float xvalue = player[0] - enemy[0];
		float yvalue = player[1] - enemy[1];

		radian = MathF.Atan(yvalue/xvalue);

		float[] output = {xvalue, yvalue, radian};

		return output;
	}

	public float Rotation(float[] player, float[] enemy, float radian){
        
        float initangle = (float)radian*Mathf.Rad2Deg;

		if(player[0] < enemy[0] && player[1] < enemy[1]){
			evenmoremath = initangle + 90;
		}else if(player[0] > enemy[0] && player[1] < enemy[1]){
			evenmoremath = initangle - 90;
		}else if(player[0] > enemy[0] && player[1] > enemy[1]){
			evenmoremath = initangle - 90;
		}else{
			evenmoremath = initangle + 90;
		}
		return evenmoremath;
	}

    public bool InRange(float[] player, float[] enemy){
        float xvalue = Mathf.Pow(player[0]-enemy[0], 2);
        float yvalue = Mathf.Pow(player[1]-enemy[1], 2);

        float distance = Mathf.Sqrt(xvalue+yvalue);

        if (distance <= 5){
            return true;
        }else{
            return false;
        }
    }

	public void targetting(float playerRotation){

		Quaternion target = Quaternion.Euler(0, 0, playerRotation);
		transform.rotation = Quaternion.Slerp(transform.rotation, 
											  target, Time.deltaTime*speed);
                                              
		float Rotation;
		if (transform.eulerAngles.z <= 180f){
			Rotation = transform.eulerAngles.z;
		} else {
			Rotation = transform.eulerAngles.z - 360f;
		}

		if(Rotation <= playerRotation+5f && Rotation >= playerRotation-5f){
			//Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAaaAAAAAAAAAAAAAAAaaaaAAAA");
		}

	}

	private void FixedUpdate() 
    {   
        physicsBody.AddForce(playerPosition);
    }
}