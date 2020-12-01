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
        float scroll = lsc.GetComponent<LevelScrollManager>().scroll;
        if (Active){
            ahead+=speed;
        }
        float loc = 0f;
        if (ahead < scroll){
            loc += (-scroll + ahead);
        }else if (ahead - (scroll-200) < 0){
            Debug.Log("hi");
            ahead = scroll - 200;
        }
        if (p != null){
            transform.position  = new Vector3(loc,p.transform.position.y,0);
        }
        
        speed = Mathf.Clamp(scroll / 5000,0.1f,0.12f) ;
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
