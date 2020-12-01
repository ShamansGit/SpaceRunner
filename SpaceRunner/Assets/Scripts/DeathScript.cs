using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deathText;
    public GameObject resetButton;
    public GameObject menuButton;
    public Text text;
    private Button reset,menu;
    public GameObject player,weapon;
    void Start()
    {
        Time.timeScale = 1;

        text = deathText.GetComponent<Text>();
        reset = resetButton.GetComponent<Button>();
        reset.onClick.AddListener(Reset);

        menu = menuButton.GetComponent<Button>();
        menu.onClick.AddListener(Menu);
        gameObject.GetComponent<Canvas> ().enabled = false;
    }

    // Update is called once per frame
    public void Die(string reason){
        gameObject.GetComponent<Canvas>().enabled = true;
        gameObject.GetComponent<AudioSource>().Play();
        //Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        text.text = reason;
    }
    void Reset(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Menu(){
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);
    }
}
