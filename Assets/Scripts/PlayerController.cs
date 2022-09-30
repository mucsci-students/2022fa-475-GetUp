using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int currentPower = 0;
    public GameObject[] powerups;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentPower >= powerups.Length - 1)
                currentPower = 0;
            else
                ++currentPower;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentPower <= 0)
                currentPower = powerups.Length - 1;
            else
                --currentPower;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatePowerup();
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + (h * Time.deltaTime * moveSpeed), transform.position.y);
    }

    void CreatePowerup()
    {
        if (powerups[currentPower].CompareTag("Bomb"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(powerups[currentPower], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
        }
        
        else
            Instantiate(powerups[currentPower], new Vector2(transform.position.x + 0.1f, transform.position.y), Quaternion.identity);
    }
}
