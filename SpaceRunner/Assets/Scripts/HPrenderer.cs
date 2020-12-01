using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPrenderer : MonoBehaviour
{
    private GameObject player;
    private Text text;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = gameObject.GetComponent<Text>();
    }
    void LateUpdate()
    {
        if (player != null){
            text.text = Mathf.CeilToInt(player.GetComponent<HealthScript>().hp).ToString();
        }else{
            text.text = "";
        }
    }
}
