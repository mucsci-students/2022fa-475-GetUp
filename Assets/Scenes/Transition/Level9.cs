using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level9 : MonoBehaviour
{
 public string ninth = "Level 9";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        SceneManager.LoadScene(ninth);
    }
}