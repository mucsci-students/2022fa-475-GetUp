using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPowerA : MonoBehaviour
{
    // Start is called before the first frame update
   public int amount;
public GameObject collidedWith;

    public SpriteRenderer appleIcon;


        void OnTriggerEnter2D(Collider2D other) 
        {  
            
            if(collidedWith.tag == other.tag){
                PlayerController.appleQuantity += amount;
                appleIcon.color = new Color (0,0,0,0);
                Destroy(this);
                
            }
            //  Debug.Log(PlayerController.appleQuantity);

        }
}