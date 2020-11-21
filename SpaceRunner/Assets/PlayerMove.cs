using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    public float speed,vert = 1f;
    public Vector2 vel;
    public Vector2 xvelr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        //Input.GetAxis("Horizontal")
        vel = new Vector2(0f* speed,Input.GetAxis("Vertical")* vert);
        rb.position = new Vector2(0f,rb.position.y);
        if(vel != Vector2.zero){
            rb.AddForce(vel);
        }
    }
}
