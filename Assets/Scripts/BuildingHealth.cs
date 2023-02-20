using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public int startingHealth = 100; // starting health of the building
    private int currentHealth; // current health of the building

    private void Start()
    {
        currentHealth = startingHealth; // set the current health to the starting health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // decrease the current health by the damage taken

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // destroy the gameObject (building/cube) when its health is 0 or less
        }
    }
}
