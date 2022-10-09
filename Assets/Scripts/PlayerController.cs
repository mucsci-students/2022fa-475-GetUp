using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int bombQuantity = 0;
    public static int appleQuantity = 0;
    public static int freezeQuantity = 0;

    private bool control = true;
    private int currentPower = 0;
    private float moveSpeedDefault;
    private float direction = -1;
    private Rigidbody2D rb;
    private CircleCollider2D circCol;
    private Animator anim;
    private AudioSource[] sfx;
    [SerializeField]
    private LayerMask groundLayerMasks;

    public GameObject[] powerups;
    public float moveSpeed = 5;
    public float jumpSpeed = 200f;

    // Start is called before the first frame update
    void Start() {
        anim = transform.Find("PlayerMonster").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circCol = GetComponent<CircleCollider2D>();
        sfx = GetComponents<AudioSource>();
        moveSpeedDefault = moveSpeed;
        
        bombQuantity = 0;
        appleQuantity = 0;
        freezeQuantity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!control)
            return;

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
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && IsGrounded())
        {
            sfx[0].Play();
            rb.AddForce(new Vector2(0, jumpSpeed));
        }
    }

    bool IsGrounded()
    {
        return (Physics2D.Raycast(circCol.bounds.center, Vector2.down, circCol.bounds.extents.y + .01f, groundLayerMasks).collider != null);
    }

    void FixedUpdate()
    {
        if (!control)
            return;

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
        if (powerups[currentPower].CompareTag("Bomb") && bombQuantity != 0)
        {
            anim.SetTrigger("drop");
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(powerups[currentPower], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
            --bombQuantity;
        }
        else if(powerups[currentPower].CompareTag("Ice Potion") && freezeQuantity != 0){
            anim.SetTrigger("drop");
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(powerups[currentPower], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
            --freezeQuantity;
        }
        else if((powerups[currentPower].CompareTag("Apple") && appleQuantity != 0))
        {
            anim.SetTrigger("attack");

            Instantiate(powerups[currentPower], new Vector2(transform.position.x + (-0.1f * direction) + (Input.GetAxis("Horizontal") / 2), transform.position.y), Quaternion.identity);
            --appleQuantity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Killzone"))
        {
            control = false;
            rb.AddForce(transform.up * Random.Range(300f, 600f));
            rb.AddForce(-transform.right * Random.Range(30f, 60f));
            circCol.enabled = false;
            sfx[1].Play();
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
