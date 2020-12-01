using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    public float shake;
    public float step;
    private GameObject player;
    void Start(){
        player = GameObject.Find("Player");
    }
    void FixedUpdate()
    {
        //shake+=0.1f;
        shake = shake * step;
        if (player != null){
            transform.position = new Vector3(0, player.transform.position.y+shake, -10f);            
        }

    }
}
