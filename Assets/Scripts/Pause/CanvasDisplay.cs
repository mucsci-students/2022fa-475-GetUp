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
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseControl.paused){
            PauseCanvas.enabled = true;
        }
        else if(PauseControl.paused == false){
            PauseCanvas.enabled = false;
        }
    }
}
