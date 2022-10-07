using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    // Start is called before the first frame update
 public string third = "Level 3";

    // Update is called once per frame
    public void OnMouseDown ()
    {
        SceneManager.LoadScene(third);
    }
}
