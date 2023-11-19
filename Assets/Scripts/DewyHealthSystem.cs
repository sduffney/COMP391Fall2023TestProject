using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DewyHealthSystem : MonoBehaviour
{
    
    public float maxHealth = 100;
    public float currentHealth;

    private float damageTimer = 0.0f;
    private float damageCooldown = 1.0f;

    public GameObject gameOverMenu;
    private AudioSource[] sounds;
    private Rigidbody2D rb;
    private bool isDead;
    void Start()
    {
        gameOverMenu.SetActive(false);
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        sounds= GetComponents<AudioSource>();
        isDead = false;
    }

    public void TakeDamage(int amount)
    {
        if (damageTimer > damageCooldown && !isDead)
        {
            currentHealth -= amount;
            damageTimer = 0.0f;
            sounds[1].Play();
        }
        if (currentHealth <= 0 && !isDead)
        {
            gameOverMenu.SetActive(true);
            sounds[0].Play();
            isDead = true;
            //Dewy is dead.
            //Go to game over scene.
        }

    }

    void Heal(int amount)
    {
        if (!isDead)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    private void Update() //For testing purposes. Remove later.
    {
        damageTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(10);
        }
        if (isDead)
        {
            rb.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
   
}
