using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    Vector3 lastVelocity;
    public int speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = GameObject.Find("Anchor").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void LateUpdate(){
        lastVelocity = rb.velocity;
    }
    void OnCollisionEnter2D(Collision2D col){
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,1f);
        //make sound
        if (col.transform.tag == "Player"){
            if (col.gameObject.GetComponent<HealthScript>().hp < col.gameObject.GetComponent<HealthScript>().maxHp){
                col.gameObject.GetComponent<HealthScript>().hp = col.gameObject.GetComponent<HealthScript>().maxHp;
                Destroy(gameObject);
            }
        }
    }
}
