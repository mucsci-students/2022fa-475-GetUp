using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumeclick : MonoBehaviour
{
    public void OnMouseDown(){
        PauseControl.paused = false;
        PauseControl.PauseUnpause();
    }


    void Update()
    {
        
    }
}
