using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPower : MonoBehaviour
{
    public int amount;
    public GameObject collidedWith;

    public SpriteRenderer freezeIcon;


        void OnTriggerEnter2D(Collider2D other) 
        {  
            
            if(collidedWith.tag == other.tag){
                PlayerController.freezeQuantity += amount;
                freezeIcon.color = new Color (0,0,0,0);
                Destroy(this);
                
            }
            // Debug.Log(PlayerController.freezeQuantity);


        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
