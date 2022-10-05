using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDisplay : MonoBehaviour
{
    public Canvas PauseCanvas;
    public GameObject background;

    void Start(){
    PauseCanvas = GetComponent<Canvas>();
    Debug.Log(PauseCanvas.enabled);
    background = GameObject.Find("pause background");
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseControl.paused){
            PauseCanvas.enabled = true;
            background.SetActive(true);
        }
        else if(PauseControl.paused == false){
            PauseCanvas.enabled = false;
            background.SetActive(false);
        }
    }
}
