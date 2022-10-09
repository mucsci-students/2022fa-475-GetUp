using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public GameObject iceFloor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(iceFloor, new Vector2(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
        Destroy(gameObject);
    }
}
