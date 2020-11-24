using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject resume,menu,quit;
    private bool isOpen = false;
    void Start()
    {
        resume.GetComponent<Button>().onClick.AddListener(Resume);
        menu.GetComponent<Button>().onClick.AddListener(Menu);
        quit.GetComponent<Button>().onClick.AddListener(Quit);
        gameObject.GetComponent<Canvas>().enabled = false;
    }
    void LateUpdate(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen == false){
                isOpen = true;
                Open();
            }else{
                isOpen = false;
                Close();
            }
            
        }
    }
    void Open(){
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<Canvas>().enabled = true;
    }
    void Close(){
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.GetComponent<Canvas>().enabled = false;
    }
    void Resume(){
        Close();
    }
    void Menu(){
        EnemyScript.dronesAlive = 0;
        SceneManager.LoadScene(0);
    }
    void Quit(){
        Application.Quit();
    }
}

