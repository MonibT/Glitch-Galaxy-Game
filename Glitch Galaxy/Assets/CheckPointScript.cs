using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    Collider2D coll;
    PlayerLife playerLife;
    public AudioSource passingsound;

    private void Start()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            passingsound.Play();
            coll.enabled = false;
            playerLife.UpdateCheckPoint(transform.position);
        }
    }
}
