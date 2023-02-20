using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public int startingHealth = 50; // starting health of the building
    private int currentHealth; // current health of the building

    public Slider healthBar; // reference to the health bar slider
    
    private void Start()
    {
        slider.maxValue = startingHealth; // set the max value of the health bar slider
        currentHealth = startingHealth; // set the current health to the starting health
        healthBar.maxValue = startingHealth; // set the max value of the health bar slider
        healthBar.value = currentHealth; // set the value of the health bar slider to the current health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // decrease the current health by the damage taken

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // destroy the gameObject (building/cube) when its health is 0 or less
        }

        healthBar.value = currentHealth; // update the value of the health bar slider to the current health
    }
}





