using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMove : MonoBehaviour
{
    // Start is called before the first frame update

    // allows user to modify force applied to astroid
    [SerializeField]private Vector2 moveforce;

    // Stores Rigid body for astroids
    public Rigidbody2D astroid= null;
    void Start()
    {
        // sets rigidbody to Rigidbody2D if it was not already decleared
        if(astroid ==null){
           astroid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Applies to force to astroid
        astroid.AddForce(moveforce, (ForceMode2D)ForceMode.Impulse);
    }
}
