using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject Laser;
    public float speed,range,hrange;
    public int clip,maxClip = 3;
    public float dmg;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 playerPos,pos;
    public bool alerted;
    public int reload,maxreload,emptyclipreload;
    //public AudioSource shoot;
    //public Sprite shootSprite,idleSprite;
    //public AudioClip die;
    public float bulletSpeed;
    void Start()
    {
        clip = maxClip;
        reload = maxreload;
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (clip <= 0){
            reload = emptyclipreload;
            clip = maxClip;
        }
        reload--;
        
        playerPos = new Vector2(player.transform.position.x,player.transform.position.y);
        pos = new Vector2(transform.position.x,transform.position.y);
        if (Vector2.Distance(playerPos,pos) <= range){
            alerted = true;   
        }else if (Vector2.Distance(playerPos,pos) >= 20){
            alerted = false;
        }
        if (alerted){
            if (Vector2.Distance(playerPos,pos) >= range / hrange){
                rb.velocity = (playerPos-pos).normalized * speed;
            }else{
                rb.velocity = (pos-playerPos).normalized * speed;
            }
            if (rb.velocity.x < 0){
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }else{
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            
        }
        if (reload <= 0 && alerted){
            //if player does not move the enemy will not attack
            reload = maxreload;
            clip--;
            //GetComponent<SpriteRenderer>().sprite = shootSprite;
            Shoot();
            
            
        }else if (reload >= (maxreload / 2)){
            //GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
    }
    void Shoot(){
        //GetComponent<SpriteRenderer>().sprite = shootSprite;
        //shoot.Play();
        GameObject b = Instantiate(Laser,transform.position,Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = (playerPos-pos).normalized * bulletSpeed;
        b.GetComponent<LaserScript>().damage = dmg;
    }
}
