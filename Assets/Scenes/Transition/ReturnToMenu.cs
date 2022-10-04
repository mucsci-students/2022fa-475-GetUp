using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public string  loader = "Menu";

    void OnMouseDown(){
        SceneManager.LoadScene(loader);
    }
}
