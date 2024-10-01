using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAbility : MonoBehaviour
{
    private bool isFiringButtonDown = false;

    public enum FiringState {Ready, WindUp, Firing, Winddown, OnCooldown};

    public float timer;

    public FiringState firingState; 
    // Update is called once per frame
    void Update()
    {
        isFiringButtonDown = Input.GetKeyDown(KeyCode.Space);

        if(isFiringButtonDown){
            firingState = FiringState.WindUp;
        }


        switch (firingState){
            case FiringState.Ready:
                Debug.Log("ready");
                break;
            case FiringState.WindUp:
                timer+=Time.deltaTime;
                Debug.Log("Winding up");
                if(timer>1){
                    firingState = FiringState.Firing;
                    timer=0;
                }
                break;
            case FiringState.Firing:
                Debug.Log("Firing");
                firingState = FiringState.Winddown;
                break;
            case FiringState.Winddown:
                Debug.Log("Winding Down");
                timer+=Time.deltaTime;
                if(timer>1){
                    firingState = FiringState.OnCooldown;
                    timer=0;
                }
                break;
            case FiringState.OnCooldown:
            Debug.Log("Cools Down");
                timer+=Time.deltaTime;
                if(timer>3){
                    firingState = FiringState.Ready;
                    timer=0;
                }
                break;
        }
    }
}
