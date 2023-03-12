using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    private GameObject _base;

    private GameObject _resource;

    public bool isGathering = false;
    
    private NavMeshAgent _agent;

    private ResourceNode _resourceScript;
    

    public GameObject Resource
    {
        set => _resource = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _base ??= GameObject.FindWithTag("Base");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGathering()
    {
        StartCoroutine(GatherResource());
    }

    IEnumerator GatherResource()
    {
        _agent.SetDestination(_resource.transform.position);
        var gold = 0;
        while (_agent.pathPending)
        {
            yield return null;
        }
        if(!_agent.hasPath && _agent.pathEndPosition == _resource.transform.position)
        {
            yield return new WaitForSeconds(1.0f);
            gold = _resourceScript.HarvestResource();
            _agent.SetDestination(_base.transform.position);
        }
        while (_agent.pathPending)
        {
            yield return null;
        } 
        if(!_agent.hasPath && _agent.pathEndPosition == _base.transform.position)
        {
            yield return new WaitForSeconds(1.0f);
            GameManager.Instance.AddGold(gold);
            StartCoroutine(GatherResource());
        }

    }
}
