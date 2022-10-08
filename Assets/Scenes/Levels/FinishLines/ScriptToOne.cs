using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptToOne : MonoBehaviour
{
    public string toLoad ="Level 1";
    
    public GameObject collidedWith;
        void OnTriggerEnter2D(Collider2D other) 
        {  
            
            if(collidedWith.tag == other.tag){
                completion.completionarr[0] = true;
                SceneManager.LoadScene(toLoad);
            } 

        }
}
