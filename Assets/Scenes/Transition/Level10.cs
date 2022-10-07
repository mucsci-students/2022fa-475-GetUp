using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level10 : MonoBehaviour
{
 public string tenth = "Level 10";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        SceneManager.LoadScene(tenth);
    }
}