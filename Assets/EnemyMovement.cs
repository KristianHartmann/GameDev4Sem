using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;

    public float aggroRange = 15f; 

    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < aggroRange)

    {

        navMeshAgent.isStopped = false; 

        navMeshAgent.SetDestination(player.position);

    }

    else

    {

        navMeshAgent.isStopped = true; 

    }
    }
}
