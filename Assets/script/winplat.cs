using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winplat : MonoBehaviour {

    public GameObject winUI;
    public float time = 5.0f;
    
    public static bool Youwin = true;

    public float autoload;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            /*if (Youwin)
            {
                winUI.SetActive(true);
                Time.timeScale = 0f;
                Youwin = true;
                
            }*/
            if (Youwin)
            {
                winUI.SetActive(true);
                time -= (Time.timeScale * 5.0f);
               if (time <= 0)
                {
                    LoadNextLevel();
                }
            }
            
            
        }
    }

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        //SceneManager.LoadScene(level);
    }
}
