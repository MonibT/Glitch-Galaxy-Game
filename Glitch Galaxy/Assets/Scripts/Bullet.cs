using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public int damage = 10;
    public float speed = 20f;
    public Enemy enemy;
    public GameObject impactEffect;

    // Start is called before the first frame update
    public void Start()
    {
        rb.velocity = transform.right  * speed; 

        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        

        enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            
        }
        Destroy(gameObject);

        Instantiate(impactEffect, transform.position, transform.rotation);

        
    }


}
