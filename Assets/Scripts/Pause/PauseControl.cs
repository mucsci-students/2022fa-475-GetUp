using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseControl : MonoBehaviour
{
public static bool paused = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
            PauseUnpause();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            RestartLevel();
        }
    }

    public static void PauseUnpause(){
        if(paused){
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
