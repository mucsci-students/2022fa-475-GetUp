using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fieldOfImpact;
    public float force;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DetonateCountdown());
    }

    IEnumerator DetonateCountdown()
    {
        yield return new WaitForSeconds(3.0f);
        Detonate();
    }

    void Detonate()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layer);

        foreach(Collider2D obj in objects)
        {
            Vector2 dir = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(dir * force);
        }

        Destroy(gameObject);
    }
}
