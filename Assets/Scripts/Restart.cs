using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
public GameObject collidedWith;

        void OnTriggerEnter2D(Collider2D other) 
        {  
            
            if(other.CompareTag("Player")){
                PauseControl.RestartLevel();
            }
        }
}
