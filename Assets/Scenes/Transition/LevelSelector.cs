using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelSelector : MonoBehaviour
{
    public string LevelSelectors = "LevelSelector";

    public void loadLevelSelector(){
        SceneManager.LoadScene(LevelSelectors);
        PauseControl.paused = false;
        PauseControl.PauseUnpause();

    }
}
