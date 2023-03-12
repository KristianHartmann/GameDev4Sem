using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    
    
    UnitSelector unitSelector;
    // Start is called before the first frame update
    void Start()
    {
        unitSelector = GetComponent<UnitSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = unitSelector.cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    MoveUnits(hit.point);
                }
            }
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void MoveUnits(Vector3 destination)
    {
        foreach (GameObject unit in unitSelector.units)
        {
            NavMeshAgent agent = unit.GetComponent<NavMeshAgent>();
            agent.SetDestination(destination);
        }
    }
}
