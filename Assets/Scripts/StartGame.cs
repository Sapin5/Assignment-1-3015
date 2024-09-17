using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu = null;
    public static bool start = false;
    void Awake(){
        Time.timeScale = 0;
    }

    public void Onstart(){
        start=true;
        Time.timeScale= 1;
        menu.SetActive(false);
    }
}
