using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FreezeCounterUpdate : MonoBehaviour
{
    public TMP_Text freezeUpdate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        freezeUpdate.SetText(PlayerController.freezeQuantity.ToString());
    }
}
