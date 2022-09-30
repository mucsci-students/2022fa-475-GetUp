using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float force;
    public float resistGravityLength;
    public float lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
        StartCoroutine(ApplyGravity());
        StartCoroutine(WitherCountdown());
    }

    IEnumerator ApplyGravity()
    {
        yield return new WaitForSeconds(resistGravityLength);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    IEnumerator WitherCountdown()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
