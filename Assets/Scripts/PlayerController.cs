using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int currentPower = 0;
    private float moveSpeedDefault;
    private float direction = -1;

    public GameObject[] powerups;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeedDefault = moveSpeed;
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

        if (h > 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            direction = -1;
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            direction = 1;
        }

        if (moveSpeed > moveSpeedDefault)
            moveSpeed *= 0.97f;
        else
            moveSpeed = moveSpeedDefault;
    }

    void CreatePowerup()
    {
        if (powerups[currentPower].CompareTag("Bomb") || powerups[currentPower].CompareTag("Ice Potion"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(powerups[currentPower], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
        }

        else
            Instantiate(powerups[currentPower], new Vector2(transform.position.x + (-0.1f * direction), transform.position.y), Quaternion.identity);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ice Floor"))
        {
            float h = Input.GetAxis("Horizontal");

            if (h != 0)
                moveSpeed *= 1.05f;
        }
    }
}
