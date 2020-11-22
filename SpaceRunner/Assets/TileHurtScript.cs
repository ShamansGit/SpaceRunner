using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHurtScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Player" || col.gameObject.name == "Shooter"){
            col.gameObject.GetComponent<HealthScript>().hp = 0.1f;
        }
    }
}
