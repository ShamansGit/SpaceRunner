using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonRotate : MonoBehaviour
{
    void Start(){
        Debug.Log("test");
    }
    void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0,0,0.1f));
    }
}
