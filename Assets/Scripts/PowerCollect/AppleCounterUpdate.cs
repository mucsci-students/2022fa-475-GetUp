using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AppleCounterUpdate : MonoBehaviour
{
    public TMP_Text appleUpdate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        appleUpdate.SetText(PlayerController.appleQuantity.ToString());
    }
}
