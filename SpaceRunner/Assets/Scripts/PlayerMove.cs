using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public SpriteRenderer gunSprite;
    public float speed,vert = 1f;
    public int jet,maxjet;
    public Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gunSprite = gameObject.transform.GetChild(2).transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = 0;
        if (Input.GetAxis("Vertical") == 0){
            if (jet < maxjet){
                jet+=6;
            }
        }else if (jet > 0){
            jet-=7;
        }
        if (jet <= 0){
            v = 0;
            jet = 0;
        }else{
            v = vert;
        }
        
        rb.velocity = new Vector2(0,rb.velocity.y);

        if (Input.GetAxis("Horizontal")<0f){
            gunSprite.flipY = true;
            gameObject.transform.GetChild(1).transform.localScale = new Vector3(-1,1,1);
        }else if (Input.GetAxis("Horizontal")>0f){
            gunSprite.flipY = false;
            gameObject.transform.GetChild(1).transform.localScale = new Vector3(1,1,1);
        }
        
        vel = new Vector2(0f,Input.GetAxis("Vertical")* v);
        rb.position = new Vector2(0f,rb.position.y);
        if(vel != Vector2.zero){
            rb.AddForce(vel);
        }
    }
    void OnCollisionStay2D(Collision2D col){
        if (jet < maxjet){
            jet+=10;
        }
    }
}
