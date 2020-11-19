using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    GameObject lsc;
    public int ahead;
    public int myIndex;
    void Start()
    {
        ahead -=10;
        lsc = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float loc = -(lsc.GetComponent<LevelScrollManager>().scroll + ahead);
        transform.position  = new Vector3(loc,0,0);
        if (transform.position.x <=-100){
            Destroy(gameObject);
            lsc.GetComponent<LevelScrollManager>().sl[myIndex] = false;
        }
    }
}
