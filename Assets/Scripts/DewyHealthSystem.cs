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
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (damageTimer > damageCooldown)
        {
            currentHealth -= amount;
            damageTimer = 0.0f;
        }
        if (currentHealth < 0)
        {
            //Dewy is dead.
            //Go to game over scene.
        }

    }

    void Heal(int amount)
    {

        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
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
    }

    // Update is called once per frame
   
}
