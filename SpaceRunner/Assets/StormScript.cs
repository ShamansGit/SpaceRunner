using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormScript : MonoBehaviour
{
    GameObject lsc;
    public float ahead,speed;
    private GameObject p;
    void Start()
    {
        //ahead -=20;
        lsc = GameObject.FindGameObjectWithTag("LevelManager");
        p = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ahead+=speed;
        float loc = 0f;
        if (ahead < lsc.GetComponent<LevelScrollManager>().scroll){
            loc += (-lsc.GetComponent<LevelScrollManager>().scroll + ahead);

        }
        transform.position  = new Vector3(loc,p.transform.position.y,0);
        
    }
}
