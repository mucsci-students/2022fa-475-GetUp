using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptToOne : MonoBehaviour
{
    public int level;
    public string toLoad;
    
    public GameObject collidedWith;
        void OnTriggerEnter2D(Collider2D other) 
        {  
            
            if(other.CompareTag("Player")){
                completion.completionarr[level] = true;
                SceneManager.LoadScene(toLoad);
            } 

        }
}
