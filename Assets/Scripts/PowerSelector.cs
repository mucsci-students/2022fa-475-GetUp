using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSelector : MonoBehaviour
{
    
    public SpriteRenderer HolderBomb;
    public SpriteRenderer HolderApple;
    public SpriteRenderer HolderFreeze;

    private int[] cycle = {0,1,2};
    private int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (index >= cycle.Length - 1)
                index = 0;
            else
                ++index;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (index <= 0)
                index = cycle.Length - 1;
            else
                --index;
        }
 
        if (cycle[index] == 0){
            HolderBomb.color = new Color (1, 0, 0, 1);
            HolderApple.color = new Color (1, 1, 1, 1);
            HolderFreeze.color = new Color (1, 1, 1, 1);
        }
        if (cycle[index] == 1){
            HolderBomb.color = new Color (1, 1, 1, 1);
            HolderApple.color = new Color (1, 0, 0, 1);
            HolderFreeze.color = new Color (1, 1, 1, 1);
        }
        if (cycle[index] == 2){
            HolderBomb.color = new Color (1, 1, 1, 1);
            HolderApple.color = new Color (1, 1, 1, 1);
            HolderFreeze.color = new Color (1, 0, 0, 1);
        }
        
    }
}
