using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuset : MonoBehaviour {

    public static bool Gameispaused = false;

    public GameObject pasedUI;

    public string level;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Gameispaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
    public void Resume()
    {
        pasedUI.SetActive(false);
        Time.timeScale = 1f;
        Gameispaused = false;
    }

    void Pause()
    {
        pasedUI.SetActive(true);
        Time.timeScale = 0f;
        Gameispaused = true;
    }
    public void loadlevel (){
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);

    }
}
