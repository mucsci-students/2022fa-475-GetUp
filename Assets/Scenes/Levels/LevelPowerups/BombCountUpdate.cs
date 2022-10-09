using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BombCountUpdate : MonoBehaviour
{
    public TMP_Text bombUpdate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bombUpdate.SetText(PlayerController.bombQuantity.ToString());
    }
}