using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
public GameObject bullet,player,shootPoint;
    public int reload,maxreload;
    public AudioSource Shoot;
    public float sShake;
    private Vector2 offset;
    void Start()
    {
        reload = maxreload;
        player = gameObject.transform.parent.gameObject;
    }
    void FixedUpdate()
    {
        reload++;
        Vector3 pos = shootPoint.transform.position;
        Aim();
        if(Input.GetMouseButton(0) && reload >= maxreload){
            //Shoot.pitch = Random.Range(1f,1.1f);
            GameObject.Find("Main Camera").GetComponent<ShakeScript>().shake = sShake;
            Shoot.Play();
            reload = 0;
            GameObject b = Instantiate(bullet,pos,shootPoint.transform.rotation);
            b.GetComponent<Rigidbody2D>().velocity = offset.normalized *25;
            b.transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(offset.y,offset.x)*Mathf.Rad2Deg);
        }
        
    }
    void Aim(){
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = new Vector2(mouse.x - screenPoint.x,mouse.y - screenPoint.y);
        float rot = Mathf.Atan2(offset.y,offset.x);
        transform.rotation = Quaternion.Euler(0,0,rot* Mathf.Rad2Deg);
    }
}
