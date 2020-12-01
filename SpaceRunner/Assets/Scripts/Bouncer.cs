using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public AudioSource bounce; 
    private Rigidbody2D rb;
    private GameObject player;
    Vector3 lastVelocity;
    public int speed;
    public int damage;
    
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
        if (player != null){
            if (Vector2.Distance(rb.position,player.transform.position) < 10){
                rb.AddForce((player.transform.position - transform.position).normalized * speed);
            }else{
                rb.velocity = new Vector2(0,0);
            }            
        }
        if (transform.position.y < -100){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,0.5f);
        bounce.Play();
        //make sound
        if (col.transform.tag == "Player"){
            player.GetComponent<HealthScript>().hp -= damage;
            if(col.gameObject.GetComponent<HealthScript>().hp<=0){
                GameObject.Find("deathScreen").GetComponent<DeathScript>().Die("PRICKLED TO DEATH");
            }             
        }
    }
}
