using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public float maxHp,hp,preHp = 0;
    // public int invuntime,invun;
    public bool resetOnDeath,drops = false;
    public GameObject drop;
    public int dropAmount;
    public Vector2 spread;
    void Start()
    {
        hp = maxHp;
        preHp = hp;
        // invun = 0;
    }
    void FixedUpdate()
    {
        // //invun
        
        // if (preHp > hp){
        //     invun = invuntime;
        //     preHp = hp;
        //     hp = preHp;
            
        // }
        // else if (invun > 0){
        //     hp = preHp;
            
        //     invun--;
        // }
        
        
        if (hp <= 0){
            if (drops){
                DropItem();
            }
            if (resetOnDeath){
                //GameObject.Find("deathScreen").GetComponent<DeathScript>().Die("lol bye");
                //transform.position = new Vector2(100,transform.position.y);
                Destroy(gameObject);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }else{
                Destroy(gameObject);
            }
        }
    }
    void DropItem(){
        for (int i = 0; i < dropAmount; i++)
        {
            GameObject d = Instantiate(drop,transform.position,Quaternion.identity);
            d.GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(-spread.x,spread.x),Random.Range(-spread.y,spread.y));
        }
    }
}
