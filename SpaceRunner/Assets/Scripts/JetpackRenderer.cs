using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackRenderer : MonoBehaviour
{
    private GameObject power;
    void Start()
    {
        power = gameObject.transform.GetChild(0).gameObject;
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow)){
            gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.95f,1.05f);
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetAxisRaw("Vertical") > 0f){
            gameObject.GetComponent<ParticleSystem>().Play(); 

        }else{
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
        float jet = gameObject.transform.parent.parent.gameObject.GetComponent<PlayerMove>().jet;
        float maxjet = gameObject.transform.parent.parent.gameObject.GetComponent<PlayerMove>().maxjet;
        power.transform.localScale = new Vector3(1f,jet/maxjet,1f);
    }
}
