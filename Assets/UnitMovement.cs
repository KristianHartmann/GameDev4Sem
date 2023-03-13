using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class UnitMovement : MonoBehaviour
{
    private Camera _myCam;
    private NavMeshAgent _myAgent;
    [SerializeField] private List<GameObject> tasks;
    private Worker _worker;
    private Animator anim;

    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        _myCam = Camera.main;
        _myAgent = GetComponent<NavMeshAgent>();
        _worker ??= gameObject.GetComponent<Worker>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = _myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                if (hit.collider.gameObject.CompareTag("resource"))
                {
                    if (gameObject.CompareTag("Worker"))
                    {
                        Debug.Log("Work Work");
                        _worker.Resource = hit.collider.gameObject;
                        _worker.isGathering = true;
                        _worker.StartGathering();
                        tasks.ForEach(t => Destroy(t));
                        tasks.Clear();
                    }
                }
                GameObject task = new GameObject();
                task.transform.position = hit.point;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    tasks.Add(task);
                }
                else
                {
                    tasks.ForEach(t => Destroy(t));
                    tasks.Clear();
                    tasks.Add(task);
                    _myAgent.SetDestination(hit.point);
                }
            }

        }

        if (_myAgent.remainingDistance < 0.5f)
        {
            if (tasks.Count > 0)
            {
                Destroy(tasks[0]);
                tasks.RemoveAt(0);
                if (tasks.Count > 0)
                {
                    _myAgent.SetDestination(tasks[0].transform.position);
                }
                if (anim != null)
                {
                    anim.SetFloat("Speed", 0);
                }
            }
        }
        else
        {
            if (anim != null)
            {
                anim.SetFloat("Speed", _myAgent.speed);
            }

        }
    }
}
