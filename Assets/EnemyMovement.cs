using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // speed of the enemy
    public float attackRange = 2f; // range at which the enemy will attack the building
    public int attackDamage = 10; // damage the enemy will do when it attacks the building

    private Transform target; // target building (cube)

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("BuildingSample").transform; // find the target building (cube) in the scene
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); // calculate the distance between the enemy and the building

        if (distance <= attackRange)
        {
            // attack the building if the distance is within the attack range
            BuildingHealth buildingHealth = target.GetComponent<BuildingHealth>(); // get the building's health script
            buildingHealth.TakeDamage(attackDamage); // call the TakeDamage method to decrease the building's health
        }
        else
        {
            // move towards the building if the distance is not within the attack range
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
