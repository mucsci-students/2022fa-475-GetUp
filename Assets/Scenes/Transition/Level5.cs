using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5 : MonoBehaviour
{
 public string fifth = "Level 5";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        SceneManager.LoadScene(fifth);
    }
}
