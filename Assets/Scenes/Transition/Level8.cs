using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level8 : MonoBehaviour
{
 public string eigth = "Level 8";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        if(completion.completionarr[7])
        SceneManager.LoadScene(eigth);
    }
}