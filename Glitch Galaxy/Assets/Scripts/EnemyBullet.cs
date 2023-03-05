using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public int damage = 10;
    public float speed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerLife player = hitInfo.GetComponent<PlayerLife>();
        if (player != null)
        {
            
            player.TakeDamage(damage);

        }

        Destroy(gameObject);

    }

}
