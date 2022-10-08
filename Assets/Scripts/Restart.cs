using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
public GameObject collidedWith;

        void OnTriggerEnter2D(Collider2D other) 
        {  
            if(collidedWith.tag == other.tag){
                Debug.Log("poke");
                PauseControl.RestartLevel();
            }
        }
}
