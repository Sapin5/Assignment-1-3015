using UnityEngine;

public class Boost : MonoBehaviour
{
    public SpriteRenderer mainFlame, leftFlame, rightFlame;
    private GameObject playerObj;
    void Start()
    {
       	if (playerObj == null){
			playerObj = gameObject;
		}
    }

    // Update is called once per frame
    void Update()
    {
        mainFlame.enabled=false;
        float angelRot = playerObj.transform.eulerAngles.z;
        float distance = Movement.singleton.totalspeed();
        Debug.Log(distance);
		if (angelRot <= 180f){
            rightFlame.enabled=false;
            leftFlame.enabled=true;
		}else{
            rightFlame.enabled=true;
            leftFlame.enabled=false;
		}

        if(distance>=.5){
            mainFlame.enabled=true;
        }else{
            mainFlame.enabled=false;
        }
    }
}
