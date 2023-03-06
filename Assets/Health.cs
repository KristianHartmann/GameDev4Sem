using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    
    private int currentHealth = 100; 
    private int maxhealth = 100; 

    private bool isDead = false;

    [SerializeField] private HealthDisplay healthDisplay;

    void Update()
    {
        if (isDead) return; 

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth > 0) return;

        OnDeath();
    }

    private void OnDeath()
    {
        isDead = true;
        var ragdoll = GetComponent<RagdollHandler>();
        ragdoll.GoRagdoll(true);

        GetComponent<NavMeshAgent>().isStopped = true;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthDisplay.SetCurrentHealth(healthDisplay.GetCurrentHealth() - damage);
    }
}
