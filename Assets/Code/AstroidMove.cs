using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Vector2 moveforce;
    public Rigidbody2D astroid= null;
    void Start()
    {
        if(astroid ==null){
           astroid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        astroid.AddForce(moveforce, (ForceMode2D)ForceMode.Impulse);
    }
}
