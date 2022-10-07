using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour
{
 public string fourth = "Level 4";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        SceneManager.LoadScene(fourth);
    }
}
