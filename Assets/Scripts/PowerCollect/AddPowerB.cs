using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPowerB : MonoBehaviour
{
   public int amount;
    public GameObject collidedWith;

    public SpriteRenderer bombIcon;


        void OnTriggerEnter2D(Collider2D other) 
        {  
            
            if(collidedWith.tag == other.tag){
                PlayerController.bombQuantity += amount;
                bombIcon.color = new Color (0,0,0,0);
                Destroy(this);
                
            }
            // Debug.Log(PlayerController.bombQuantity);


        }
}
