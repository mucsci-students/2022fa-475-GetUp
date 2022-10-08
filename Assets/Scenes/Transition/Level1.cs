using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
 public string first = "Level 1";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        if(completion.completionarr[0])
            SceneManager.LoadScene(first);
    }
}
