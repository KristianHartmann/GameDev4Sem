using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{

    public string resourceType;
    
    private int _resourceAmount;
    public int resourceCapacity;
    public int resourcePerTick;
    // Start is called before the first frame update
    void Start()
    {
        _resourceAmount = resourceCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int HarvestResource()
    {
        if(_resourceAmount > 0)
        {
            _resourceAmount -= resourcePerTick;
            return resourcePerTick;
        }else{
            return 0;
        }
    }
}
