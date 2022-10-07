using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 

    private int currentPower = 0;
    private float moveSpeedDefault;
    private float direction = -1;

    public GameObject[] powerups;
    public float moveSpeed = 5;
    public float JumpSpeed = 500f;
    Rigidbody2D rigidB;
    Animator anim;
    

    public float JumpCoolDown = .65f;
    bool InAir = false;


    // Start is called before the first frame update
    void Start() {
        anim = transform.Find("PlayerMonster").GetComponent<Animator>();
        rigidB = GetComponent<Rigidbody2D>();
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
            if (PauseControl.paused == false){
                CreatePowerup();
            }

        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && InAir == false)
        {
            StartCoroutine(Jumper());
        }
    }

    IEnumerator Jumper()
    {
        rigidB.AddForce(new Vector2(0, JumpSpeed));
        InAir = true;
        yield return new WaitForSeconds(JumpCoolDown);
        InAir = false;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + (h * Time.deltaTime * moveSpeed), transform.position.y);

        if (h != 0)
        {
            anim.SetBool("isMoving", true);

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
        }
        else
            anim.SetBool("isMoving", false);

        if (moveSpeed > moveSpeedDefault)
            moveSpeed *= .97f;
        else
            moveSpeed = moveSpeedDefault;
        }

    void CreatePowerup()
    {
        if (powerups[currentPower].CompareTag("Bomb") || powerups[currentPower].CompareTag("Ice Potion"))
        {
            anim.SetTrigger("drop");
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(powerups[currentPower], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
        }

        else
        {
            anim.SetTrigger("attack");
            Instantiate(powerups[currentPower], new Vector2(transform.position.x + (-0.1f * direction), transform.position.y), Quaternion.identity);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ice Floor"))
        {
            float h = Input.GetAxis("Horizontal");

            if (h != 0 && moveSpeed < 10f)
                moveSpeed *= 1.05f;
        }
    }
}
