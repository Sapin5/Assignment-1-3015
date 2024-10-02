using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Program
{
    public static void Main()
    {
        var letter = new List<char> { 'a', 'b' };
        letter.Add('c');
        letter.Add('d');
        letter.Remove('c');
        Console.WriteLine(String.Join(", ", letter)); // a, b, d
    }
}


public class AstroidDetection : MonoBehaviour
{
    private Vector2 curPos;
    private Vector2 astroidPos;
    private ArrayList astroids = new ArrayList();
    private int astroidCount = 0;
    public void Update(){
        curPos = new Vector2(transform.position.x, transform.position.y);
    }
    public void OnTriggerStay2D(Collider2D collider){
        if(collider.CompareTag("Red"))
        {
            astroidPos = new Vector2(collider.transform.position.x,
                                    collider.transform.position.y);
            Debug.DrawLine(curPos, astroidPos);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Red")){
            astroids.Add(collider);
            astroidCount+=1;
        }
        Debug.Log($"Length of list is: {astroids.Count}\nAstroids int range is {astroidCount}");
    }

    public void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Red")){
            astroids.Remove(collider);
            astroidCount-=1;
        }
        Debug.Log($"Length of list is: {astroids.Count}\nAstroids int range is {astroidCount}");
    }
}