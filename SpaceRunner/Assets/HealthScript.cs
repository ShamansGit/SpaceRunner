using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public float maxHp,hp,preHp = 0;
    // public int invuntime,invun;
    public bool resetOnDeath = false;
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
            if (resetOnDeath){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }else{
                Destroy(gameObject);
            }
        }
    }
}
