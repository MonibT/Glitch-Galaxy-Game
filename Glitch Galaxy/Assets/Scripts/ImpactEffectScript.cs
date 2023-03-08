using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffectScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D coll;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coll.enabled = !coll.enabled;

        Destroy(gameObject, 0.38f);

    }
}
