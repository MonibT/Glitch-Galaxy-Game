using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator anim;
    public int maxHealth = 100;
    public int currentHealth;
    public int TrapDamage = 34;

    public HealthBarScipt healthBar; 

    public AudioSource deathsound;
    public AudioSource DamageSound;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

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
        deathsound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        coll.enabled = false;
        anim.SetTrigger("death");
        
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
