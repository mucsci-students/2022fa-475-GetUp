using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer appleRenderer;
    private bool canKill = true;

    public float force;
    public float resistGravityLength;
    public float activeLength;
    public float lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        appleRenderer = GetComponent<SpriteRenderer>();
        float playerDirection = GameObject.FindGameObjectWithTag("Player").transform.localScale.x * -2;
        print(playerDirection);

        GetComponent<Rigidbody2D>().AddForce(playerDirection * transform.right * force);
        StartCoroutine(ApplyGravity());
        StartCoroutine(ActiveCountdown());
        StartCoroutine(WitherCountdown());
    }

    IEnumerator ApplyGravity()
    {
        yield return new WaitForSeconds(resistGravityLength);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    IEnumerator ActiveCountdown()
    {
        yield return new WaitForSeconds(activeLength);
        appleRenderer.color = Color.black;
        canKill = false;
    }

    IEnumerator WitherCountdown()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        if (!canKill && !collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    public bool CanKill()
    {
        return canKill;
    }
}
