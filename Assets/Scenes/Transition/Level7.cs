using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level7 : MonoBehaviour
{
 public string seventh = "Level 7";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        if(completion.completionarr[6])
        SceneManager.LoadScene(seventh);
    }
}