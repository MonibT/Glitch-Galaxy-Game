using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public Text LivesText;
    private int LivesNum = 3;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator anim;
    public int maxHealth = 100;
    public int currentHealth;
    public int TrapDamage = 50;

    Vector2 CheckPointPos;
    

    public HealthBarScipt healthBar; 

    public AudioSource deathsound;
    public AudioSource DamageSound;
    private void Start()
    {
        CheckPointPos = transform.position;
        currentHealth = maxHealth;
        


        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();

    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            TakeDamage(TrapDamage);
            
        }

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        DamageSound.Play();

        if (currentHealth <= 0)
        {   

            Die();
        }

    }

    private void Die()
    {
        coll.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        LivesNum--;
        LivesText.text = "Lives: " + LivesNum;
        deathsound.Play();
        anim.SetTrigger("death");
        if(LivesNum == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    public void UpdateCheckPoint(Vector2 Pos)
    {
        CheckPointPos = Pos;
    }
    private void RestartLevel()
    {
        coll.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        currentHealth = maxHealth;
        anim.SetTrigger("Respawn");
        healthBar.SetHealth(maxHealth);
        transform.position = CheckPointPos;
    }
}
