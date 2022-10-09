using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;
    private AudioSource deathSfx;
    private float moveSpeedDefault;

    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.Find("EnemySlimeMonster").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        deathSfx = GetComponent<AudioSource>();
        anim.SetBool("isMoving", true);
        moveSpeedDefault = moveSpeed;
    }

    private void FixedUpdate()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);

        if (moveSpeed > moveSpeedDefault)
            moveSpeed *= .97f;
        else
            moveSpeed = moveSpeedDefault;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple") && collision.gameObject.GetComponent<Apple>().CanKill())
        {
            Destroy(collision.gameObject);
            TriggerDeath();
        }
        //Spikes under Killzone tag
        else if (collision.gameObject.CompareTag("Killzone"))
        {
            TriggerDeath();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ice Floor") && moveSpeed < 5f)
            moveSpeed *= 1.05f;
    }

    public void TriggerDeath()
    {
        deathSfx.Play();
        rb.AddForce(transform.up * Random.Range(300f, 600f));
        rb.AddForce(transform.right * Random.Range(30f, 60f));
        boxCol.enabled = false;
        StartCoroutine(DeleteFromExistence());
    }

    IEnumerator DeleteFromExistence()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
