using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6 : MonoBehaviour
{
 public string sixth = "Level 6";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        SceneManager.LoadScene(sixth);
    }
}