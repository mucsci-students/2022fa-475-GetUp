using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public float fieldOfImpact;
    public float force;
    public Text countdownText;
    public LayerMask layer;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        var countText = Instantiate(countdownText, transform.position, Quaternion.identity);
        countText.GetComponent<BombCountdown>().lookAt = transform;

        countText.transform.SetParent(GameObject.Find("OnScreenInfo").transform);
        StartCoroutine(DetonateCountdown());
    }

    IEnumerator DetonateCountdown()
    {
        yield return new WaitForSeconds(3.0f);
        Detonate();
    }

    void Detonate()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layer);

        foreach(Collider2D obj in objects)
        {
            Vector2 dir = obj.transform.position - transform.position;

            if(obj.GetComponent<Rigidbody2D>() != null)
                obj.GetComponent<Rigidbody2D>().AddForce(dir * force);

            if (obj.gameObject.CompareTag("Enemy"))
            {
                obj.gameObject.GetComponent<EnemySlime>().TriggerDeath();
            }
        }

        Destroy(gameObject);
    }
}
