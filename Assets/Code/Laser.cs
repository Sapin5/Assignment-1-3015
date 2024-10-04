using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laser;
    private float laserSizeX, laserSizeY, initSize;
    private float timer;
    private bool firing = false;
    // Start is called before the first frame update
    void Start()
    {
        laserSizeX = laser.transform.localScale.x;
        laserSizeY = laser.transform.localScale.y;
        initSize = 0;
        laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            laser.SetActive(true);
            firing = true;
        }

        if(firing && timer <1){
            timer+=Time.deltaTime;
            initSize+=Time.deltaTime*.1f;
            laser.transform.localScale = new Vector2(1, 0.75f);
        }else{
            timer = 0;
            initSize = 0;
            firing = false;
            laser.SetActive(false);
        }
    }
}
