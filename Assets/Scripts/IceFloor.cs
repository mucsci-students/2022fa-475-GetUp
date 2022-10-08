using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public float meltTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MeltFloor());
    }

    IEnumerator MeltFloor()
    {
        yield return new WaitForSeconds(meltTime);
        Destroy(gameObject);
    }
}
