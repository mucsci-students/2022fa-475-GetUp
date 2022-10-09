using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCountdown : MonoBehaviour
{
    [Header("Tweaks")]
    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    [Header("Logic")]
    private Camera cam;
    private Text textText;

    // Start is called before the first frame update
    void Start()
    {
        textText = GetComponent<Text>();
        cam = Camera.main;
        StartCoroutine(Countdown(3));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);

        if (transform.position != pos)
            transform.position = pos;
    }

    IEnumerator Countdown(int num)
    {
        yield return new WaitForSeconds(1f);
        --num;
        textText.text = num.ToString();

        if (num == 0)
            Destroy(gameObject);
        else
            StartCoroutine(Countdown(num));
    }
}
