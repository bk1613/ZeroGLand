using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour {

    // Use this for initialization
    /*public void LoadStartMenu()
    {

        SceneManager.LoadScene(0);

    }*/

    public void LoadLevel(string name)
    {

        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
