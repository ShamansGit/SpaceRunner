using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tease : MonoBehaviour
{
    public string[] teases;
    void Start()
    {
        gameObject.GetComponent<Text>().text = teases[Random.Range(0,teases.Length)];
    }
}
