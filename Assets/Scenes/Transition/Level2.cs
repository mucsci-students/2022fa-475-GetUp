using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public string second = "Level 2";

    public void OnMouseDown ()
    {
        if(completion.completionarr[1])
        SceneManager.LoadScene(second);
    }
}
