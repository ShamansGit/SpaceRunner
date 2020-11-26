using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    GameObject lsc;
    public int ahead;
    public int myIndex;
    public float movea = 1f;
    public bool persistent = false;
    private float scr;
    void Start()
    {
        ahead -=10;
        lsc = GameObject.FindGameObjectWithTag("LevelManager");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scr =lsc.GetComponent<LevelScrollManager>().scroll;
        float loc = -((scr*movea) + ahead);
        transform.position  = new Vector3(loc,0,0);
        if (transform.position.x <=-40 && !persistent){
            Destroy(gameObject);
            lsc.GetComponent<LevelScrollManager>().sl[myIndex] = false;
        }
    }
}
