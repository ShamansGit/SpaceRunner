using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
public GameObject WizBullet;
    public float hp,mhp,speed,range,hrange;
    public int dmg;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 playerPos,pos;
    public bool alerted;
    public int reload,maxreload;
    public AudioSource shoot;
    public Sprite shootSprite,idleSprite;
    public AudioClip die;
    public GameObject coin;
    public float bulletSpeed;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        hp = mhp;
    }
    void FixedUpdate()
    {
        reload++;
        
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
        if (reload >= maxreload && alerted){
            //if player does not move the enemy will not attack
            reload = 0;
            GetComponent<SpriteRenderer>().sprite = shootSprite;
            Shoot();
            
            
        }else if (reload >= (maxreload / 2)){
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
    }
    void Shoot(){
        //GetComponent<SpriteRenderer>().sprite = shootSprite;
        shoot.Play();
        GameObject b = Instantiate(WizBullet,transform.position,Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = (playerPos-pos).normalized * bulletSpeed;
    }
}
