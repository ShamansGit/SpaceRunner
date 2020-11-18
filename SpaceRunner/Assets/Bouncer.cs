using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    Vector3 lastVelocity;
    public int speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
        //rb.position = new Vector2(rb.position.x+=GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelScrollManager>().scroll,rb.position.y);
        rb.AddForce((player.transform.position - transform.position).normalized * speed);

        if (transform.position.y < -100){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,1f);
        //make sound
        //hurt player
    }
}
