using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bomb;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            SetBomb();
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + (h * Time.deltaTime * moveSpeed), transform.position.y);
    }

    void SetBomb()
    {
        Instantiate(bomb, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
    }
}
