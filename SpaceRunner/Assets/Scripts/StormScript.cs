using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormScript : MonoBehaviour
{
    GameObject lsc;
    public float ahead,speed,dmg;
    private GameObject p;
    public bool Active;
    void Start()
    {
        //ahead -=20;
        lsc = GameObject.FindGameObjectWithTag("LevelManager");
        p = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Active){
            ahead+=speed;
        }
        float loc = 0f;
        if (ahead < lsc.GetComponent<LevelScrollManager>().scroll){
            loc += (-lsc.GetComponent<LevelScrollManager>().scroll + ahead);

        }
        transform.position  = new Vector3(loc,p.transform.position.y,0);
        
    }
    void OnTriggerStay2D(Collider2D col){
        if (col.transform.tag =="Player"){
            col.gameObject.GetComponent<HealthScript>().hp -= dmg;
            if(col.gameObject.GetComponent<HealthScript>().hp<=0){
                GameObject.Find("deathScreen").GetComponent<DeathScript>().Die("lost to the storm");
            }    
        }

    }
}
