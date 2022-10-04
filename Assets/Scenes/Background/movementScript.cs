using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float speed = 5f;
    static float upperX = 58f;
    static float lowerX = 2.857f;

    // public static float lowerX{ get; set;}
    // public static float upperX{get; set;}

    Vector3 scene = new Vector3(lowerX,0f,-10f);



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Time.deltaTime,0f, 0f);
        if (transform.position.x >= upperX){
            transform.position = scene;
        }
    }
}
