using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int maxHp,hp,invuntime = 0;
    public int invun,preHp;
    public bool resetOnDeath = false;
    void Start()
    {
        hp = maxHp;
        preHp = hp;
        invun = 0;
    }
    void FixedUpdate()
    {
        //invun
        if (preHp > hp){
            invun = invuntime;
        }
        preHp = hp;
        if (invun > 0){
            hp = preHp;
            invun--;
        }
        if (hp <= 0 && invun>0){
            if (resetOnDeath){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }else{
                Destroy(gameObject);
            }
        }
    }
}
