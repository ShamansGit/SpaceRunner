using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Play);
    }
    void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
