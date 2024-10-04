using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;


public class AstroidDetection : MonoBehaviour
{
    // Stores current position
    private Vector2 curPos;
    // Stores Astroids position
    private Vector2 astroidPos;
    // Stores astroids in list to track how many are in range
    private ArrayList astroids = new ArrayList();
    // Counts astroids in range
    private int astroidCount = 0;
    // calls once per frame
    public void Update(){
        // Updates players current location 
        curPos = new Vector2(transform.position.x, transform.position.y);
    }
    
    // Runs while a collider is within it triggering it
    public void OnTriggerStay2D(Collider2D collider){
        // If the tag is red it will draw a line from
        // the player to the astroid
        if(collider.CompareTag("Red"))
        {
            // Updates astroids currentposition
            astroidPos = new Vector2(collider.transform.position.x,
                                    collider.transform.position.y);
            // Draws line to Astroid from player
            Debug.DrawLine(curPos, astroidPos);
        }
    }

    // Runs when astroid enters range
    public void OnTriggerEnter2D(Collider2D collider){
        // if an item with red tag enters collider
        // adds astroid to list and increments astroid count by one
        if(collider.CompareTag("Red")){
            astroids.Add(collider);
            astroidCount+=1;
            Debug.Log($"{astroids.Count} Astroids are in array\n{astroidCount} Astroids are in Range");
        }
    }

    // Runs when astroid exits collider
    public void OnTriggerExit2D(Collider2D collider){
        // if an item with red tag exits collider
        // remoces astroid from list and
        // decreases astroid count by one
        if(collider.CompareTag("Red")){
            astroids.Remove(collider);
            astroidCount-=1;
            Debug.Log($"{astroids.Count} Are in array\n{astroidCount} Are in Range");
        }
    }
}