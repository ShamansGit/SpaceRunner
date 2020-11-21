using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private int lifetime;
    public int damage;
    public int endurance = 100;
    private static AudioSource auds;
    private Rigidbody2D rb;
    public GameObject Hitfx;
    public bool freindly;
    void Start()
    { 
        gameObject.transform.parent = GameObject.Find("Anchor").transform;
        auds = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();
 
    }
    void FixedUpdate()
    {

        //Vector2 loc = new Vector2(transform.position.x + (Input.GetAxis("Horizontal")*0.025f),transform.position.y);
        //rb.position = loc;
        //   rb.MovePosition(loc);

        lifetime = lifetime+1;
        if(lifetime>endurance){
            Destroy(gameObject);
        }
    }  
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.transform.tag == "Enemy" && freindly){
            //auds.Play();
            col.transform.GetComponent<HealthScript>().hp -= damage; 
            // GameObject fx = Instantiate(Hitfx,transform.position,Quaternion.Euler(0,0,0));
            // Destroy(fx,0.4f);
            
        }else if (col.gameObject.transform.tag == "Player" && !freindly){
            col.transform.GetComponent<HealthScript>().hp -= damage; 
        }
        Destroy(gameObject);
    }  
}
