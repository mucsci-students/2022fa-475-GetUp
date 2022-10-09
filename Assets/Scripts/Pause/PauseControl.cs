using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    private AudioSource[] sfx;
    public static bool paused = false;

    void Start()
    {
        sfx = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
            PlayPauseSfx();
            PauseUnpause();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            RestartLevel();
        }
    }

    public static void PauseUnpause() {
        if(paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public static void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PlayPauseSfx()
    {
        if (paused)
            sfx[2].Play();
        else
            sfx[3].Play();
    }
}
