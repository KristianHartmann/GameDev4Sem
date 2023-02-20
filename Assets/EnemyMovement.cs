using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // speed of the enemy
    public float attackInterval = 1f; // interval between each attack
    public int attackDamage = 10; // damage the enemy will do when it attacks the building

    private Transform target; // target building (cube)
    private BuildingHealth targetHealth; // reference to the target building's health script
    private float attackTimer = 0f; // timer for the next attack
    private float attackRange = 2; // range of the attack

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("BuildingSample").transform; // find the target building (cube) in the scene
        targetHealth = target.GetComponent<BuildingHealth>(); // get the building's health script
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); // calculate the distance between the enemy and the building

        if (distance <= attackRange)
        {
            // attack the building if the distance is within the attack range
            if (attackTimer >= attackInterval)
            {
                targetHealth.TakeDamage(attackDamage); // call the TakeDamage method to decrease the building's health
                attackTimer = 0f; // reset the attack timer
            }
            else
            {
                attackTimer += Time.deltaTime; // increase the attack timer
            }
        }
        else
        {
            // move towards the building if the distance is not within the attack range
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}