using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScrollManager : MonoBehaviour
{
    public GameObject[] lvls;
    public List<bool> sl = new List<bool>();
    public float scroll;
    public int step;
    private GameObject p;
    void Start()
    {
        scroll = 0f;
        sl.Add(false);
        p = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scroll+=(Input.GetAxis("Horizontal")/8)+p.transform.position.x;
        if (scroll < 0){
            scroll = 0;
        }
        
        int index = Mathf.RoundToInt(scroll)/step;
        if (sl[index] != true){
            sl[index] = true;
            GameObject level = Instantiate(lvls[Random.Range(0,2)],new Vector3(scroll,0f,0f),Quaternion.identity);
            level.GetComponent<LevelScroll>().ahead = -((step * index)+(step/2));
            level.GetComponent<LevelScroll>().myIndex = index;
            sl.Add(false);
            
        }
    }
}
