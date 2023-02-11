using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Pineapples = 0;
    public Text PineapplesText;
    public AudioSource collectsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            Destroy(collision.gameObject);
            Pineapples++;
            collectsound.Play();
            PineapplesText.text = "Pineapples: " + Pineapples;

        }
    }

    
}
