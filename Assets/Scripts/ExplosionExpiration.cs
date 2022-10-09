using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionExpiration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dissipate());
    }

    IEnumerator Dissipate()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
